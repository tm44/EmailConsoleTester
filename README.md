# EmailConsoleTester

## Steps to run
Run an `npm install` to bring in necessary packages.

Place the .html email template file in the C:\temp folder (or wherever, and adjust the code accordingly).

Create a free SMTP account with [SendInBlue.com](https://sendinblue.com).  Once the account is set up, log in and go to the "Transactional" menu item.  Click on Settings from the left menu, then Configuration, then "Get Your SMTP key"

Create an appsettings.json file that looks like the following:

```
  "Settings": {
    "SmtpHost": "smtp-relay.sendinblue.com",
    "Username": "YourUsername",
    "Password": "YourPassword",
    "To": "test@email.com",
    "From": "your@email.com",
    "Port": 587
  }
```