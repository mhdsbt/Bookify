using Bookify.Application.Abstraction;
using Bookify.Application.Abstraction.Data;
using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Entities.Apratment;
using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Enums;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments.SearchApartments
{
    public sealed class SearchApartmentQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
    {
        private static readonly int[] ActiveBookingStatuses =
        {
            (int)BookingStatus.Reserved,
            (int )BookingStatus.Confirmed, (int )BookingStatus.Completed
        };

        private readonly ISqlConnectionFactory _connectionFactory;

        public SearchApartmentQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
        {

            if(request.startDate > request.endDate)
            {
                return Result.Success<IReadOnlyList<ApartmentResponse>>(new List<ApartmentResponse>());
            }

            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT 
                    a.id As Id,
                    a.Name As Name,
                    a.description AS Description,
                    a.price_amount As Price,
                    a.address_Country As Country,
                    a.address_state As state
                FROM apartments As a
                WHERE NOT EXISTS 
                (
                    SELECT 1 
                    FROM bookings  AS b
                    WHERE
                    b.apartment_id = a.id AND
                    b.duration_start <= @EndDate AND 
                    b.duration_end  >= @startDate AND 
                    b.status = ANY(@ActiveBookingStatuses)
                    )
                """;

            var apartmetns = await connection.QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                    sql,
                (apartment, address) =>
                {
                    apartment.Address = address;
                    return apartment;

                },
                new
                {
                    request.startDate,
                    request.endDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country");

            return Result.Success<IReadOnlyList<ApartmentResponse>>(apartmetns.ToList());

        }
    }
}
