using bArtTask.Entities;

namespace bArtTask.Repositories.Interfaces;

public interface IIncidentRepository
{
    Task<Account> GetAccountByNameAsync(string accountName);
    Task<Contact> GetContactByEmailAsync(string email);
    Task AddContactAsync(Contact contact);
    Task AddIncidentAsync(Incident incident);
    Task SaveChangesAsync();
}