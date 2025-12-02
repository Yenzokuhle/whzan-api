using Whzan_API.EF.Models;

namespace Whzan_API.EF.SeedingData
{
    public static class ProductImagesSeeding
    {
        // ----------------------
        // Products
        // ----------------------
        public static Product product1 = new Product()
        {
            Id = 1,
            Name = "JBL Live 770NC Wireless Bluetooth Over-Ear Noise Cancelling Headphones",
            Description = "JBL Live 770NC headphones deliver powerful JBL Signature Sound in a comfortable over-ear headband style.",
            Brand = "JBL",
            Price = 1925M,
            Currency = "Rands",
            Rating = 4.3M,
            ReviewCount = 103,
            IsPredefined = true,
            InStock = true
        };

        public static Product product2 = new Product()
        {
            Id = 2,
            Name = "Timex Expedition Gallatin Solar-Powered (TW4B14500)",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Brand = "Timex",
            Price = 2399M,
            Currency = "Rands",
            Rating = 3.8M,
            ReviewCount = 25,
            IsPredefined = true,
            InStock = true
        };

        public static Product product3 = new Product()
        {
            Id = 3,
            Name = "Soundcore by Anker Liberty 4 NC Wireless Noise Cancelling Earbuds",
            Description = "98.5% Noise Reduction. Adaptive Noise Cancelling. Hi-Res Sound. 50H Battery. Wireless Charging. Bluetooth 5.3",
            Brand = "Soundcore",
            Price = 1299M,
            Currency = "Rands",
            Rating = 4.5M,
            ReviewCount = 32,
            IsPredefined = true,
            InStock = false
        };

        public static Product product4 = new Product()
        {
            Id = 4,
            Name = "Beyerdynamic AVENTHO 100 Wireless On-Ear Headphones With ANC - Cream",
            Description = "Beyerdynamic AVENTHO 100 features more than 60 hours playtime & up to 40 hours with ANC.",
            Brand = "Beyerdynamic",
            Price = 4499M,
            Currency = "Rands",
            Rating = 4.1M,
            ReviewCount = 77,
            IsPredefined = true,
            InStock = true
        };

        public static Product product5 = new Product()
        {
            Id = 5,
            Name = "JBL PartyBox On-The-Go 2 Portable Bluetooth Party Speaker with Wireless Mic",
            Description = "JBL Pro Sound, Dynamic Lightshow, 15H Playtime, Auracast Multi-Speaker Connection & Splashproof",
            Brand = "JBL",
            Price = 5999M,
            Currency = "Rands",
            Rating = 4.2M,
            ReviewCount = 61,
            IsPredefined = true,
            InStock = true
        };

        public static Product product6 = new Product()
        {
            Id = 6,
            Name = "Hisense 65inch E7Q 4K UHD QLED Smart TV with Dolby Vision",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Brand = "Hisense",
            Price = 7999M,
            Currency = "Rands",
            Rating = 4.8M,
            ReviewCount = 22,
            IsPredefined = true,
            InStock = true
        };

        public static Product product7 = new Product()
        {
            Id = 7,
            Name = "HUAWEI FreeBuds SE 3 -Earphones/Wireless Earbuds|42-Hour Battery Life-Black",
            Description = "3-Hour Listening on 10-minute Charge | Long Press to Pair| Bluetooth5.4 Connect | IP54 Dust &Splash-Resistance",
            Brand = "Huawei",
            Price = 999M,
            Currency = "Rands",
            Rating = 4.5M,
            ReviewCount = 87,
            IsPredefined = true,
            InStock = false
        };

        public static Product product8 = new Product()
        {
            Id = 8,
            Name = "Sennheiser MOMENTUM 4 Wireless Over-Ear Noise Cancelling Headphones (Teal)",
            Description = "Wireless Over-Ear Noise Cancelling Headphones",
            Brand = "Sennheiser",
            Price = 5450M,
            Currency = "Rands",
            Rating = 3.5M,
            ReviewCount = 50,
            IsPredefined = true,
            InStock = true
        };

        // ----------------------
        // Images
        // ----------------------
        public static Image image1 = new Image() { Id = 1, ImageURL = "https://media.takealot.com/covers_images/ada2654a1b6f49e298336ac8e5e4d156/s-zoom.file" };
        public static Image image2 = new Image() { Id = 2, ImageURL = "https://media.takealot.com/covers_images/d6849ec5f50a409aa6306255409957e3/s-zoom.file" };
        public static Image image3 = new Image() { Id = 3, ImageURL = "https://media.takealot.com/covers_images/52fc46b0248f471db459838937999eb3/s-zoom.file" };
        public static Image image4 = new Image() { Id = 4, ImageURL = "https://media.takealot.com/covers_images/3d3c187f5fef403e88a32d56f7e0647e/s-zoom.file" };

        public static Image image5 = new Image() { Id = 5, ImageURL = "https://media.takealot.com/covers_images/ff210e16d57f48c698034c35a8dee348/s-zoom.file" };
        public static Image image6 = new Image() { Id = 6, ImageURL = "https://media.takealot.com/covers_images/2827a86a69744e36a60a375b573e9be3/s-zoom.file" };
        public static Image image7 = new Image() { Id = 7, ImageURL = "https://media.takealot.com/covers_images/599c45b09a8b41df82d0f28a8cbddc5c/s-zoom.file" };
        public static Image image8 = new Image() { Id = 8, ImageURL = "https://media.takealot.com/covers_images/2e1d4ba85c1c4a69b31454ec03a464b8/s-zoom.file" };

        public static Image image9 = new Image() { Id = 9, ImageURL = "https://media.takealot.com/covers_images/0241de942b2a431c8d326f9a4ffdbb9a/s-zoom.file" };
        public static Image image10 = new Image() { Id = 10, ImageURL = "https://media.takealot.com/covers_images/f12610962a184b00a96870ca42f36507/s-zoom.file" };
        public static Image image11 = new Image() { Id = 11, ImageURL = "https://media.takealot.com/covers_images/434e43a10f504d30b44d5b1f23c32b07/s-zoom.file" };

        public static Image image12 = new Image() { Id = 12, ImageURL = "https://media.takealot.com/covers_images/68e38c6ded394787985de7f9583b408c/s-zoom.file" };
        public static Image image13 = new Image() { Id = 13, ImageURL = "https://media.takealot.com/covers_images/1314ce11ae994990bac2320c1ee607a9/s-zoom.file" };
        public static Image image14 = new Image() { Id = 14, ImageURL = "https://media.takealot.com/covers_images/5af2807dd6f84bdb88a30f647d083a6e/s-zoom.file" };
        public static Image image15 = new Image() { Id = 15, ImageURL = "https://media.takealot.com/covers_images/cd58f55bbb4b448f99e99fbcb555493c/s-zoom.file" };

        public static Image image16 = new Image() { Id = 16, ImageURL = "https://media.takealot.com/covers_images/dddd25a12747493eb8353b10c71576a7/s-zoom.file" };
        public static Image image17 = new Image() { Id = 17, ImageURL = "https://media.takealot.com/covers_images/61625c49992241acb65b9191e21de793/s-zoom.file" };
        public static Image image18 = new Image() { Id = 18, ImageURL = "https://media.takealot.com/covers_images/0c1c1ae3580148529088079267e18f8e/s-zoom.file" };
        public static Image image19 = new Image() { Id = 19, ImageURL = "https://media.takealot.com/covers_images/7e0a4b3692cb4895b45432e89e22f978/s-zoom.file" };

        public static Image image20 = new Image() { Id = 20, ImageURL = "https://media.takealot.com/covers_images/7a9d16396be5483e9a1f3bfdc5d23ecf/s-zoom.file" };
        public static Image image21 = new Image() { Id = 21, ImageURL = "https://media.takealot.com/covers_images/f66e2b0c7aa64e3ea18055c5d44580fb/s-zoom.file" };
        public static Image image22 = new Image() { Id = 22, ImageURL = "https://media.takealot.com/covers_images/072823ead7a24449aed85592e2fec96f/s-zoom.file" };
        public static Image image23 = new Image() { Id = 23, ImageURL = "https://media.takealot.com/covers_images/dd9e2c8f33034aefb5ae921f9adb592c/s-zoom.file" };

        public static Image image24 = new Image() { Id = 24, ImageURL = "https://media.takealot.com/covers_images/825e3017cbb84c779176fc5af7f5471d/s-zoom.file" };
        public static Image image25 = new Image() { Id = 25, ImageURL = "https://media.takealot.com/covers_images/e689bb5a45994ffa832cce32fddf2a67/s-zoom.file" };
        public static Image image26 = new Image() { Id = 26, ImageURL = "https://media.takealot.com/covers_images/a35456fce4034864a82bce57674d171a/s-zoom.file" };
        public static Image image27 = new Image() { Id = 27, ImageURL = "https://media.takealot.com/covers_images/a8734d0db2554a6381e5e31a4e11a2cc/s-zoom.file" };

        public static Image image28 = new Image() { Id = 28, ImageURL = "https://media.takealot.com/covers_images/b4359d3c59c042e5a6e52aa44e8e4575/s-zoom.file" };
        public static Image image29 = new Image() { Id = 29, ImageURL = "https://media.takealot.com/covers_images/5eb9ca39bcae47e591157b989d70927e/s-zoom.file" };
        public static Image image30 = new Image() { Id = 30, ImageURL = "https://media.takealot.com/covers_images/6c861aed47a34d549f7f17b0d81c4fd3/s-zoom.file" };
        public static Image image31 = new Image() { Id = 31, ImageURL = "https://media.takealot.com/covers_images/fc1000768be64c64b3a57ffdd0691b35/s-zoom.file" };

        // ----------------------
        // ProductImages Mapping
        // ----------------------
        public static ProductImage productImage1 = new ProductImage() { Id = 1, ProductId = 1, ImageId = 1 };
        public static ProductImage productImage2 = new ProductImage() { Id = 2, ProductId = 1, ImageId = 2 };
        public static ProductImage productImage3 = new ProductImage() { Id = 3, ProductId = 1, ImageId = 3 };
        public static ProductImage productImage4 = new ProductImage() { Id = 4, ProductId = 1, ImageId = 4 };

        public static ProductImage productImage5 = new ProductImage() { Id = 5, ProductId = 2, ImageId = 5 };
        public static ProductImage productImage6 = new ProductImage() { Id = 6, ProductId = 2, ImageId = 6 };
        public static ProductImage productImage7 = new ProductImage() { Id = 7, ProductId = 2, ImageId = 7 };
        public static ProductImage productImage8 = new ProductImage() { Id = 8, ProductId = 2, ImageId = 8 };

        public static ProductImage productImage9 = new ProductImage() { Id = 9, ProductId = 3, ImageId = 9 };
        public static ProductImage productImage10 = new ProductImage() { Id = 10, ProductId = 3, ImageId = 10 };
        public static ProductImage productImage11 = new ProductImage() { Id = 11, ProductId = 3, ImageId = 11 };

        public static ProductImage productImage12 = new ProductImage() { Id = 12, ProductId = 4, ImageId = 12 };
        public static ProductImage productImage13 = new ProductImage() { Id = 13, ProductId = 4, ImageId = 13 };
        public static ProductImage productImage14 = new ProductImage() { Id = 14, ProductId = 4, ImageId = 14 };
        public static ProductImage productImage15 = new ProductImage() { Id = 15, ProductId = 4, ImageId = 15 };

        public static ProductImage productImage16 = new ProductImage() { Id = 16, ProductId = 5, ImageId = 16 };
        public static ProductImage productImage17 = new ProductImage() { Id = 17, ProductId = 5, ImageId = 17 };
        public static ProductImage productImage18 = new ProductImage() { Id = 18, ProductId = 5, ImageId = 18 };
        public static ProductImage productImage19 = new ProductImage() { Id = 19, ProductId = 5, ImageId = 19 };

        public static ProductImage productImage20 = new ProductImage() { Id = 20, ProductId = 6, ImageId = 20 };
        public static ProductImage productImage21 = new ProductImage() { Id = 21, ProductId = 6, ImageId = 21 };
        public static ProductImage productImage22 = new ProductImage() { Id = 22, ProductId = 6, ImageId = 22 };
        public static ProductImage productImage23 = new ProductImage() { Id = 23, ProductId = 6, ImageId = 23 };

        public static ProductImage productImage24 = new ProductImage() { Id = 24, ProductId = 7, ImageId = 24 };
        public static ProductImage productImage25 = new ProductImage() { Id = 25, ProductId = 7, ImageId = 25 };
        public static ProductImage productImage26 = new ProductImage() { Id = 26, ProductId = 7, ImageId = 26 };
        public static ProductImage productImage27 = new ProductImage() { Id = 27, ProductId = 7, ImageId = 27 };

        public static ProductImage productImage28 = new ProductImage() { Id = 28, ProductId = 8, ImageId = 28 };
        public static ProductImage productImage29 = new ProductImage() { Id = 29, ProductId = 8, ImageId = 29 };
        public static ProductImage productImage30 = new ProductImage() { Id = 30, ProductId = 8, ImageId = 30 };
        public static ProductImage productImage31 = new ProductImage() { Id = 31, ProductId = 8, ImageId = 31 };
    }
}
