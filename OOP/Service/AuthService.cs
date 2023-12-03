using System;
using System.Data;
using OOP.Domain;
using OOP.Repositoryy;

namespace OOP.Service {
    interface IAuthService {
        bool SignUp(string email, string password, string nickname, int money, string userType);
        UserDto LogIn(string email, string password);
    }

    internal class AuthService : IAuthService {
        public bool SignUp(string email, string password, string nickname, int money, string userType) {
            throw new System.NotImplementedException();
        }

        public UserDto LogIn(string email, string password) {
                throw new System.NotImplementedException();
            }
        }
    }

// namespace OOP.Service {
//     internal class AuthService {
//         private ProductRepository ProductRepository;
//         private UserRepository UserRepository;
//
//         public bool SignUp(string email, string password, string nickname, int money, string userType) {
//             DataRow isUserAlreadyExist = this.UserRepository.FindUserByEmail(email);
//             if (isUserAlreadyExist != null) {
//                 Console.WriteLine("중복된 이메일입니다. 다시 입력해주세요.");
//                 return false;
//             }
//
//             this.UserRepository.CreateUser(email, password, nickname, money, userType);
//             Console.WriteLine("회원가입이 완료되었습니다.");
//             return true;
//
//         }
//     }
// }

//         public UserDto Login(string email, string password) {
//             DataRow userRow = this.UserRepository.FindUserByEmailAndPassword(email, password);
//             if (userRow == null) {
//                 return null;
//             }
//             else {
//                 UserDto userDto = User.ConvertDto();
//                 return userDto;
//                 Data Row user 를 딕셔너리로 바꾸어야 함.. 
//                 파이썬에서는 user.convert_dto() 함수 실행 후 리턴
//             }
//         }
//     
//     }
// }

// 여기 자꾸 에러 나오는데....ㅠㅠ (ㅣlogin)