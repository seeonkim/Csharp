using OOP.Domain;
using OOP.Infra;

namespace OOP.Repository {
    interface IBaseRepository {
        void Save<T>(T domain) where T : BaseDomain;
    }

    public class BaseRepository {
        protected readonly IDatabase db;
        protected readonly string fileName;

        protected BaseRepository(string fileName) {
            this.db = Database.Instance;
            this.fileName = fileName;
        }

        public void Save<T>(T domain) where T : BaseDomain {
            this.db.Update(this.fileName, domain.ConvertData());
        }
    }
}