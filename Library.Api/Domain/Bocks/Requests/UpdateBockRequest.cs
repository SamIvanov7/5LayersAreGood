﻿namespace Library.Api.Domain.Bocks.Requests
{
    public class UpdateBockRequest
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

    }
}
