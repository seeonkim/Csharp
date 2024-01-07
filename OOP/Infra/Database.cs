using System.Collections.Generic;
using System.IO;
using OOP.Domain;

namespace OOP.Infra {
    public interface IDatabase {
        List<T> Read<T>(string fileName) where T : class;
        void Write(string fileName, string row);
        void Update();
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
        public void Write(string fileName, string row) {
            string filePath = this.rootDir + fileName;
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(row);
            writer.Close();
        }

        public void Update() {
        }

        public List<T> Read<T>(string fileName) where T : class {
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
            }

            reader.Close();

            return rows;
        }
    }
}