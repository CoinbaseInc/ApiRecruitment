using System.Collections.Generic;

namespace JustEat.RecruitmentTest.App
{
   public class Restaurant
    {
       public string Name { get; set; }
       public string CuisineTypes { get; set; }
       public decimal RatingStars { get; set; }
       public int NumberOfRantings { get; set; }

       public Restaurant()
       {
           Name = string.Empty;
           CuisineTypes = string.Empty;
           RatingStars = 0;
           NumberOfRantings = 0;
       }
    }
}
