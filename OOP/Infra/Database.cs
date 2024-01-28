using System;
using System.Collections.Generic;
using System.IO;
using OOP.Domain;

namespace OOP.Infra {
    public interface IDatabase {
        List<T> Read<T>(string fileName) where T : class;
        void Write(string fileName, string row);
        void Update(string fileName, string row);
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
        public void Write(string fileName, string row) {
            string filePath = this.rootDir + fileName;
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine(row);
            writer.Close();
        }

        public void Update(string fileName, string row) {
            List<string[]> rows = this.Read<string[]>(fileName);
            for (int i = 0; i < rows.Count; i++) {
                string[] findRow = rows[i];
                if (row.Split(',')[0] == findRow[0]) { 
                    rows[i] = row.Split(',');
                    break;
                }
            }
            WriteToFile(fileName, rows);
        }

        private void WriteToFile(string fileName, List<string[]> rows) {
            string filePath = Path.Combine(this.rootDir, fileName);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string[] rowData in rows)
                {
                    writer.WriteLine(string.Join(",", rowData));
                }
            }
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