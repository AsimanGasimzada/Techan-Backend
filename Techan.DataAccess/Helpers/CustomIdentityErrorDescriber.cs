using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techan.DataAccess.Localizers;

namespace Techan.DataAccess.Helpers;

internal class CustomIdentityErrorDescriber : IdentityErrorDescriber
{
    private readonly ErrorLocalizer _localizer;

    public CustomIdentityErrorDescriber(ErrorLocalizer localizer)
    {
        _localizer = localizer;
    }
    public override IdentityError ConcurrencyFailure()
    {
        return new IdentityError { Code = nameof(ConcurrencyFailure), Description = _localizer.GetValue(nameof(ConcurrencyFailure)) };
    }

    public override IdentityError DefaultError()
    {
        return new IdentityError { Code = nameof(DefaultError), Description = _localizer.GetValue(nameof(DefaultError)) };
    }

    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError { Code = nameof(DuplicateEmail), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), email) };
    }

    public override IdentityError DuplicateRoleName(string role)
    {
        return new IdentityError { Code = nameof(DuplicateRoleName), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), role) };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError { Code = nameof(DuplicateUserName), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), userName) };
    }

    public override IdentityError InvalidEmail(string? email)
    {
        return new IdentityError { Code = nameof(InvalidEmail), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), email) };
    }

    public override IdentityError InvalidRoleName(string? role)
    {
        return new IdentityError { Code = nameof(InvalidRoleName), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), role) };
    }

    public override IdentityError InvalidToken()
    {
        return new IdentityError { Code = nameof(InvalidToken), Description = _localizer.GetValue(nameof(InvalidToken)) };
    }

    public override IdentityError InvalidUserName(string? userName)
    {
        return new IdentityError { Code = nameof(InvalidUserName), Description = string.Format(_localizer.GetValue(nameof(DuplicateEmail)), userName) };
    }

    public override IdentityError LoginAlreadyAssociated()
    {
        return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = _localizer.GetValue(nameof(LoginAlreadyAssociated)) };
    }

    public override IdentityError PasswordMismatch()
    {
        return new IdentityError { Code = nameof(PasswordMismatch), Description = _localizer.GetValue(nameof(PasswordMismatch)) };
    }

    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = _localizer.GetValue(nameof(PasswordRequiresDigit)) };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError { Code = nameof(PasswordRequiresLower), Description = _localizer.GetValue(nameof(PasswordRequiresLower)) };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = _localizer.GetValue(nameof(PasswordRequiresUniqueChars)) };
    }

    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
    {
        return new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = string.Format(_localizer.GetValue(nameof(PasswordRequiresUniqueChars)), uniqueChars) };
    }

    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = _localizer.GetValue(nameof(PasswordRequiresUpper)) };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError { Code = nameof(PasswordTooShort), Description = string.Format(_localizer.GetValue(nameof(PasswordTooShort)), length) };
    }

    public override IdentityError RecoveryCodeRedemptionFailed()
    {
        return new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = _localizer.GetValue(nameof(RecoveryCodeRedemptionFailed)) };
    }

    public override IdentityError UserAlreadyHasPassword()
    {
        return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = _localizer.GetValue(nameof(UserAlreadyHasPassword)) };
    }

    public override IdentityError UserAlreadyInRole(string role)
    {
        return new IdentityError { Code = nameof(UserAlreadyInRole), Description = string.Format(_localizer.GetValue(nameof(UserAlreadyInRole)), role) };
    }

    public override IdentityError UserLockoutNotEnabled()
    {
        return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = _localizer.GetValue(nameof(UserLockoutNotEnabled)) };
    }

    public override IdentityError UserNotInRole(string role)
    {
        return new IdentityError { Code = nameof(UserNotInRole), Description = string.Format(_localizer.GetValue(nameof(UserNotInRole)), role) };
    }
}
