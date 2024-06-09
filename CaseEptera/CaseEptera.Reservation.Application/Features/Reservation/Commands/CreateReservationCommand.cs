using CaseEptera.Reservation.Application.Features.RoomQuota.Commands;
using CaseEptera.Reservation.Domain.Abstract;
using CaseEptera.Reservation.Domain.Entities;
using CaseEptera.Reservation.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Features.Reservation.Commands
{
    public class CreateReservationCommand : IRequest<ActionResponse<bool>>
    {
        public string GuestName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Child1 { get; set; }
        public int Child2 { get; set; }
        public int Child3 { get; set; }
        public Guid RoomTypeId { get; set; }
        public double Price { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ActionResponse<bool>>
    {
        private readonly IRepository<Reservationinfo> _reservationinfoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public CreateReservationCommandHandler(IRepository<Reservationinfo> reservationinfoRepository, IUnitOfWork uow, IMediator mediator)
        {
            _reservationinfoRepository = reservationinfoRepository;
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<ActionResponse<bool>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = ActionResponse<bool>.Success(200);

            try
            {
                var newRes = new Reservationinfo
                {
                    RecId = Guid.NewGuid(),
                    GuestName = request.GuestName,
                    CheckinDate = request.CheckinDate,
                    CheckoutDate = request.CheckoutDate,
                    Adult = request.Adult,
                    Child1 = request.Child1,
                    Child2 = request.Child2,
                    Child3 = request.Child3,
                    RoomTypeId = request.RoomTypeId,
                    Price = request.Price,
                    Deleted = false
                };
                await _reservationinfoRepository.AddAsync(newRes);

                UpdateRoomQuotaCommand updRoommQuota = new UpdateRoomQuotaCommand();
                updRoommQuota.RoomTypeId = request.RoomTypeId;
                await _mediator.Send(updRoommQuota);


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
