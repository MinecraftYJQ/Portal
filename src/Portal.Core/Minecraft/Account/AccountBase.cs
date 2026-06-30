namespace Portal.Core.Minecraft.Account;

public class AccountBase(AccountType accountType)
{
    public DateTime CreateAt { get; set; }
    public DateTime LastLoginTime { get; set; }
    public AccountType AccountType { get; } = accountType;
}