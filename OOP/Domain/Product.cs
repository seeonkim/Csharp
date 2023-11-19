using System.Security.AccessControl;

namespace OOP.Domain {
    internal class ProductDto {
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

    internal class Product {
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
}
