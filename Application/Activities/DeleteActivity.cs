using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Presistence;

namespace Application.Activities
{
    public class DeleteActivity
    {
        public class Command:IRequest{
            public Activity activity{ get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                
                _context.Activities.Remove(request.activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
    
}