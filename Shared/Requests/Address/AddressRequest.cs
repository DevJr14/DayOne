﻿namespace Shared.Requests.Address
{
    public class AddressRequest
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string CellphoneNo { get; set; }
        public string Email { get; set; }
    }
}
