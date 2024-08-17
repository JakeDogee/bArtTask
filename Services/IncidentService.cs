using bArtTask.Entities;
using bArtTask.Models;
using bArtTask.Repositories.Interfaces;
using bArtTask.Services.Interfaces;

namespace bArtTask.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _repository;

    public IncidentService(IIncidentRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> CreateIncidentAsync(IncidentModelRequest request)
    {
        // Step 1: Check if the account exists by name
        var account = await _repository.GetAccountByNameAsync(request.AccountName);

        if (account == null)
        {
            throw new Exception("Account not found");
        }

        // Step 2: Check if the contact exists by email
        var contact = await _repository.GetContactByEmailAsync(request.ContactEmail);

        if (contact != null)
        {
            // If contact exists but is not linked to the account, link them
            if (contact.AccountId != account.Id)
            {
                contact.AccountId = account.Id;
                await _repository.SaveChangesAsync();
            }
        }
        else
        {
            // Create a new contact and link to account
            contact = new Contact
            {
                FirstName = request.ContactFirstName,
                LastName = request.ContactLastName,
                Email = request.ContactEmail,
                Account = account
            };
            await _repository.AddContactAsync(contact);
        }

        // Step 3: Create the new incident
        var incident = new Incident
        {
            IncidentName = Guid.NewGuid().ToString(),
            Description = request.IncidentDescription,
            Account = account
        };
        await _repository.AddIncidentAsync(incident);

        // Save changes
        await _repository.SaveChangesAsync();

        return "Incident created successfully";
    }
}