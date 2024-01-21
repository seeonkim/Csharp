namespace OOP.Domain {
    // UI에서 사용하는 타입
    public class ProductDto {
        public readonly string id;
        public readonly string title;
        public readonly int price;
        public readonly string content;
        public readonly bool isSelling;
        public readonly string sellerEmail;
        public readonly string buyerEmail;

        public ProductDto(string id, string title, int price, string content, bool isSelling, string sellerEmail,
            string buyerEmail) {
            this.id = id;
            this.title = title;
            this.price = price;
            this.content = content;
            this.isSelling = isSelling;
            this.sellerEmail = sellerEmail;
            this.buyerEmail = buyerEmail;
        }
    }

    // 서비스에서 사용하는 타입
    public class Product {
        // 인스턴스 변수
        private string id;
        private string title;
        private int price;
        private string content;
        private bool isSelling;
        private string sellerEmail;
        private string buyerEmail;

        // 생성자
        public Product(string id, string title, int price, string content, bool isSelling, string sellerEmail,
            string buyerEmail) {
            this.id = id;
            this.title = title;
            this.price = price;
            this.content = content;
            this.isSelling = isSelling;
            this.sellerEmail = sellerEmail;
            this.buyerEmail = buyerEmail;
        }

        // 메소드
        public string GetId() {
            return this.id;
        }

        public string GetTitlle() {
            return this.title;
        }

        public int GetPrice() {
            return this.price;
        }

        public string GetContent() {
            return this.content;
        }

        public bool GetIsSelling() {
            return this.isSelling;
        }

        public bool GetSellerEmail() {
            return this.isSelling;
        }

        public string GetBuyerEmail() {
            return this.buyerEmail;
        }

        public ProductDto ConvertDTO() {
            return new ProductDto(this.id, this.title, this.price, this.content, this.isSelling, this.sellerEmail,
                this.buyerEmail);
        }

        // def set_sold_out(self, buyer_email):
        // self.__is_selling = False
        //     self.__buyer_email = buyer_email


        public void setSoldOut(string buyerEmail) {
            this.isSelling = false;
            this.buyerEmail = buyerEmail;
        }
    }

    // database에 저장되는 형
    public class ProductData {
        public readonly string Id;
        public readonly string Title;
        public readonly int Price;
        public readonly string Content;
        public readonly bool IsSelling;
        public readonly string SellerEmail;
        public readonly string BuyerEmail;

        public ProductData(string id, string title, string price, string content, string isSelling, string sellerEmail,
            string buyerEmail) {
            this.Id = id;
            this.Title = title;
            this.Price = int.Parse(id);
            this.Content = content;
            this.IsSelling = bool.Parse(isSelling);
            this.SellerEmail = sellerEmail;
            this.BuyerEmail = buyerEmail;
        }
    }
}