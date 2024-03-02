namespace OOP.Domain {
    // 서비스에서 사용하는 타입
    public abstract class BaseDto {
    }

    // 서비스에서 사용하는 타입
    public abstract class BaseDomain {
        public abstract BaseDto ConvertDto();
        public abstract BaseData ConvertData();
    }

    // database에 저장되는 형태
    public abstract class BaseData {
    }
}