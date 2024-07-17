using CarsiClient.Models;
using System.Xml.Linq;

namespace CarsiClient.Repo
{
    public static class Repos
    {
        private static readonly List<ProductModel> _products = [
            new ProductModel() {
                Id=1,
                Name="Kulaklik",
                ImageUrl="kulaklik.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="airpod",
                
            },
            new ProductModel() {
                Id=2,
                Name="macbook",
                ImageUrl="macbook.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="mac",


            },
            new ProductModel() {
                Id=3,
                Name="iphone13",
                ImageUrl="iphone.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="telefon",


            },
            new ProductModel() {
                Id=4,
                Name="",
                ImageUrl="airpod.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="telefon",


            },
            new ProductModel() {
                Id=5,
                Name="iped",
                ImageUrl="iped.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="telefon",


            },
            new ProductModel() {
                Id=6,
                Name="android",
                ImageUrl="android.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="telefon",


            },
            new ProductModel() {
                Id=6,
                Name="android",
                ImageUrl="android.jpg",
                Price=1500,
                Stock=1500,
                IsHome=true,
                IsActive=true,
                Description="telefon",


            },



            ];


        public static List<ProductModel> GetProducts() 
        { return _products; }

        public static ProductModel GetProduct(int id) 
        { return _products.Where(p => p.Id == id).FirstOrDefault(); }
    }
}
