using CaseEptera.Reservation.Application.Features.Reservation.Commands;
using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Domain.Entities;
using CaseEptera.Reservation.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CaseEptera.Reservation.Application.Features.RoomQuota.Commands
{
    public class UpdateRoomQuotaCommand : IRequest<ActionResponse<bool>>
    {
        public Guid RoomTypeId { get; set; }
    }

    public class UpdateRoomQuotaCommandHandler : IRequestHandler<UpdateRoomQuotaCommand, ActionResponse<bool>>
    {
        private readonly IRepository<Roomquota> _roomqoutaRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public UpdateRoomQuotaCommandHandler(IRepository<Roomquota> roomqoutaRepository, IUnitOfWork uow, IMediator mediator)
        {
            _roomqoutaRepository = roomqoutaRepository;
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<ActionResponse<bool>> Handle(UpdateRoomQuotaCommand request, CancellationToken cancellationToken)
        {
            var response = ActionResponse<bool>.Success(200);

            try
            {

                Roomquota rooms = (await _roomqoutaRepository.GetAsync(x => x.RoomTypeId == request.RoomTypeId)).FirstOrDefault();

                if (rooms != null)
                {
                    rooms.AvailableRoomCount -= 1;
                }
                _roomqoutaRepository.Update(rooms);

                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
            return response;
        }
    }
}
