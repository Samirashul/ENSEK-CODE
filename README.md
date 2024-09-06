ENSEK Technical Test:

This is a C# web project that has two POST endpoints:

The first is /account-uploads, which takes a csv file with the headers of accountId (int), FirstName (nvarchar), SurName(nvarchar). It checks that the account Id is not present in the database and if so adds the account.

The second is /meter-read-uploads, which takes a csv file with the headers of accountId (int), DateTimeStamp (datetime), and meter read (nvarchar).
It checks that the account Id exists in the database, that the date time stamp of the read is more recent that the most recent one in the database for that account, 
that a read just like it doesn't already exist, and that the meter reads is a string of at least 1 and at most 5 digits, with no other characters allowed.

Finally each endpoint will output a string informing how many accounts or meter reads were added successfully and how many failed validation.

What I could have done differently/added if I had more time:

Instead of a boolean for IsValid for meter reads I would have returned an int. This int would be symbolically representative of the validation flags (has account, is most recent read, is unique, is correct format) by using implied binary flags.
For example an error code int of 3, when converted to a 4 digit binary (one for each flag), would read 0011, meaning that it has failed the last two flags (smallest digit corresponds to first flag, and so on).
This would be used in the output to explain why a meter read failed validation.

Validate for CSV files. The endpoints assume that a CSV file is going to be passed on, but a word document could instead.

In the automated testing, instead of actually running the "GET" methods to retrieve data from the database I would introduce a mocking framework and mock the results of those methods.
Currently if the test data is deleted, some tests will fail.

Create a simple "browse for a local file and call this endpoint with it" client using React.
