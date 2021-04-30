﻿using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Status
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public StatusModel Status { get; set; }
        }

        public class Handler : IRequestHandler<Command , Result<Unit> >
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var status = await _context.Status.FindAsync(request.Status.Id);
                _mapper.Map(request.Status, status);


               var Result =  await _context.SaveChangesAsync() > 0;

                if (!Result) return Result<Unit>.Failure("Failed to create Status");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}