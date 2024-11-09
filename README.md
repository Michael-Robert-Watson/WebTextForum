# WebTextForum

When you get the project and run it - the EF will create the database and apply the migrations.  It uses SQLite for simplicity.
It will also prepopulate the db with some data, specifically the users which are:
Moderator - where all the passwords are *password*
User1
User2
User3
User4

Chrome will ask you to update the password, nevermind!

You can log in or just go directly to the Forum page to see theposts

When you have added osts, you can click on them and if you are a moderator - then you can tag the posts and save the changes.  If you are not logged in you can only LIKE a post.
If you are logged in as any user - you can reply to a post and save the reply.

Note - when you are viewing the comment with replies - if you hover over the reply, you can see who asnd when the reply was done

There are a number of tests that are part of the system

The 1 main issue that I had with SQLite was that the auto increment identity was not available - so in tables that I could - I used the int and then used the guid(tostring()) for the rest - this causes problems for the postmad scripts and you'll have to update the guids yourself