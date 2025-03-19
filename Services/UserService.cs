namespace ExceptionhandlerAndSerLog.WebAPI.Services;

public class UserService
{
	public (bool, string) Create(int age)
	{

		int a= age;
		int b = 0;
		int c = a/b;
		if (age < 18)
		{
			return (false, "Kullanıcının yaşı 18 den büyük olmalıdır");
		}
		return (true, string.Empty);
	}
}

