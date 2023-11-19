using System.IO;

namespace OOP.Infra {
    public class Database {
        public void Write() {
            // Hint 1
            // 파일에 데이터를 쓰는 방법은 아래의 코드를 참고하세요
            // StreamWriter writer = new StreamWriter("파일의 경로를 쓰세요", false);
            StreamWriter writer = new StreamWriter("파일의 경로를 쓰세요", true);
            writer.WriteLine("a,b,c");
            writer.Close();
        }

        public void Read() {
            // Hint 2
            // 파일에 데이터를 쓰는 방법은 아래의 코드를 참고하세요
            // StreamReader reader = new StreamReader("파일의 경로를 쓰세요");
            // string line = reader.ReadLine();
            // Console.WriteLine(line);
            // reader.Close();
        }
    }
}