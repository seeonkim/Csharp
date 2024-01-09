using System.Collections.Generic;
using System.IO;

namespace OOP.Infra {
    public interface IDatabase {
        List<string> Read(string fileName);
        void Write(string fileName, string row);
        void Update();
    }

    public class Database : IDatabase {
        // 클래스 변수
        private static IDatabase _instance;

        // 인스턴스 변수
        private string _rootDir;

        private Database() {
            this._rootDir = "/Users/happiness/Developer/Lecture/Sunday-2/Csharp/OOP/Data/";
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
        public List<string> Read(string fileName) {
            List<string> content = new List<string>();
            string filePath = this._rootDir + fileName;
            StreamReader reader = new StreamReader(filePath);
            while (true) {
                string line = reader.ReadLine();
                if (line == null) {
                    break;
                }

                content.Add(line);
            }

            reader.Close();

            return content;
        }

        public void Write(string fileName, string row) {
            string filePath = this._rootDir + fileName;
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(row);
            writer.Close();
        }

        public void Update() {
        }
    }
}