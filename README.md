# func-applytobecome-processapplicationform

An Azure function used to process submitted application forms from '**Apply to Become an Academy**'.

To run locally against **Dev** ensure you have either an environment variable, secret or a local.settings.json file with
the following value set to the the connection string for **Dev Database**:

`__SQLAZURECONNSTR_SqlConnectionString_`

_Note: As we cannot run the ADF pipeline against local Db, we will not have the tables or any data in a local Db._
