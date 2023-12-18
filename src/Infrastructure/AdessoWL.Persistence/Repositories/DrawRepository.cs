using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Entities;
using AdessoWL.Persistence.Context;
using System.Threading.Tasks;

namespace AdessoWL.Persistence.Repositories;

public class DrawRepository(AdessoWLContext dbContext) : IDrawRepository
{
    public async Task CreateDraw(DrawEntity drawEntity)
    {
        await dbContext.Draws.AddAsync(drawEntity);

        await dbContext.SaveChangesAsync();
    }
}
