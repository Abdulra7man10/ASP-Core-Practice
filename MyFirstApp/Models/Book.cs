using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Models
{
    public class Book
    {
        //[FromQuery]
        public int? bookId {  get; set; }
        public string? author { get; set; }

        public override string ToString()
        {
            return $"BookID : {bookId} - Author : {author}";
        }
    }
}
