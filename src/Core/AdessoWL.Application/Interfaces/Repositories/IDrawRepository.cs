using AdessoWL.Domain.Entities;
using System.Threading.Tasks;

namespace AdessoWL.Application.Interfaces.Repositories;
public interface IDrawRepository
{
    Task CreateDraw(DrawEntity drawEntity);
}
