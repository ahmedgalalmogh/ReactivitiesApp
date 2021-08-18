using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Presistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _Mapper ;

            public Handler(DataContext context, IMapper mapper)
            {
                _Mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.activity.Id);
                _Mapper.Map(request.activity,activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
                
            }
        }
    }
}