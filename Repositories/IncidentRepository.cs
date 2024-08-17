using bArtTask.Entities;
using bArtTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bArtTask.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _context;

    public IncidentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Account> GetAccountByNameAsync(string accountName)
    {
        return await _context.Accounts
            .Include(a => a.Contacts)
            .FirstOrDefaultAsync(a => a.Name == accountName);
    }

    public async Task<Contact> GetContactByEmailAsync(string email)
    {
        return await _context.Contacts
            .FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task AddContactAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
    }

    public async Task AddIncidentAsync(Incident incident)
    {
        await _context.Incidents.AddAsync(incident);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}