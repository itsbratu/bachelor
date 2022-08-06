package objectProtocol;


import concurs.domain.User;

public class LoginResponse implements Response{
    private User user;

    public LoginResponse(User user)
    {
        this.user = user;
    }

    public User getUser()
    {
        return user;
    }
}
