namespace toys.password;

public class PasswordValidations
{
    private static string _password = "";

    public static bool IsValidPassword(string password)
    {
        _password = password;
        if (!HaveLessThan20PercentRepetition())
            return false;
        
        if(!DontHaveRepetitionAfterOrBefore())
            return false;

        return true;
    }


    private static bool DontHaveRepetitionAfterOrBefore()
    {
        for (var i = 0; i < _password.Length; i++)
        {
            if(i+1 >= _password.Length) 
                break;
            if (_password[i] == _password[i + 1]) 
                return false;
        }

        return true;
    }

    private static bool HaveLessThan20PercentRepetition()
    {
        
        var maxRepetition =  Math.Round(_password.Length * 0.20) >= 1 ? Math.Round(_password.Length * 0.20) : 1;
        
        foreach (var letter in _password)
        {
            if (_password.Count(x => x == letter) > maxRepetition)
                return false;
        }

        return true;
    }
}