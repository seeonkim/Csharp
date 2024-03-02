using System.Collections.Generic;
using System.IO;
using OOP.Domain;

namespace OOP.Infra {
    public interface IDatabase {
        List<T> Read<T>(string fileName) where T : BaseData;
        void Append<T>(string fileName, T data) where T : BaseData;
        void Write<T>(string fileName, List<T> data) where T : BaseData;
        void Update<T>(string fileName, T data) where T : BaseData;
        int GetFinalId(string fileName);
    }

    public class Database : IDatabase {
        // 클래스 변수
        private static IDatabase _instance;

        // 인스턴스 변수
        private readonly string rootDir;

        private Database() {
            this.rootDir = "/Users/happiness/Developer/Lecture/Sunday-2/Csharp/OOP/Data/";
        }

        // 클래스 메소드
        public static IDatabase Instance {
            get {
                if (Database._instance == null) {
                    Database._instance = new Database();
                }

                return Database._instance;
            }
        }

        // 인스턴스 메소드
        public void Append<T>(string fileName, T data) where T : BaseData {
            if (data == null) {
                return;
            }

            string filePath = this.rootDir + fileName;
            StreamWriter writer = new StreamWriter(filePath, true);
            if (data.GetType() == typeof(UserData)) {
                UserData userData = data as UserData;
                if (userData == null) {
                    return;
                }

                writer.WriteLine(
                    $"{userData.Email},{userData.Password},{userData.Nickname},{userData.Money},{userData.UserType}");
            }
            else if (data.GetType() == typeof(ProductData)) {
                ProductData productData = data as ProductData;
                if (productData == null) {
                    return;
                }

                writer.WriteLine(
                    $"{productData.Id},{productData.Title},{productData.Price},{productData.Content},{productData.IsSelling},{productData.SellerEmail},{productData.BuyerEmail}");
            }

            writer.Close();
        }

        public void Write<T>(string fileName, List<T> data) where T : BaseData {
            string filePath = this.rootDir + fileName;
            StreamWriter writer = new StreamWriter(filePath, false);
            if (typeof(T) == typeof(UserData)) {
                string log = "";
                for (int i = 0; i < data.Count; i++) {
                    UserData userData = data[i] as UserData;
                    if (userData == null) {
                        return;
                    }

                    log +=
                        $"{userData.Email},{userData.Password},{userData.Nickname},{userData.Money},{userData.UserType}\n";
                }
                writer.Write(log);
            }

            writer.Close();
        }

        public List<T> Read<T>(string fileName) where T : BaseData {
            List<T> rows = new List<T>();
            string filePath = this.rootDir + fileName;
            StreamReader reader = new StreamReader(filePath);

            reader.ReadLine(); // 컬럼을 읽는데 소모
            while (true) {
                string line = reader.ReadLine();
                if (line == null) {
                    break;
                }

                if (typeof(T) == typeof(UserData)) {
                    rows.Add(new UserData(line.Split(',')[0], line.Split(',')[1], line.Split(',')[2],
                        line.Split(',')[3],
                        line.Split(',')[4]) as T
                    );
                }
                else if (typeof(T) == typeof(ProductData)) {
                    rows.Add(new ProductData(line.Split(',')[0], line.Split(',')[1], line.Split(',')[2],
                        line.Split(',')[3],
                        line.Split(',')[4], line.Split(',')[5], line.Split(',')[6]) as T
                    );
                }
            }

            reader.Close();

            return rows;
        }

        public void Update<T>(string fileName, T data) where T : BaseData {
            if (data.GetType() == typeof(UserData)) {
                List<UserData> rows = this.Read<UserData>(fileName);
                UserData userData = data as UserData;
                for (int i = 0; i < rows.Count; i++) {
                    UserData userRow = rows[i];
                    if (userRow.Email == userData.Email) {
                        rows[i] = userData;
                        break;
                    }
                }

                this.Write<UserData>(fileName, rows);
            }
        }

        public int GetFinalId(string fileName) {
            string filePath = this.rootDir + fileName;
            StreamReader reader = new StreamReader(filePath);

            reader.ReadLine();

            int finalId = 0;
            while (true) {
                string line = reader.ReadLine();
                if (line == null) {
                    break;
                }

                finalId += 1;
            }

            reader.Close();

            return finalId;
        }
    }
}