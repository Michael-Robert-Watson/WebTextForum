# WebTextForum

When you get the project and run it - the EF will create the database and apply the migrations.  It uses SQLite for simplicity.
It will also prepopulate the db with some data, specifically the users which are:
Moderator - where all the passwords are *password*
User1
User2
User3
User4

Chrome will ask you to update the password, nevermind!

You can log in or just go directly to the Forum page to see the posts

When you have added posts, you can click on them and if you are a moderator - then you can tag the posts and save the changes.  If you are not logged in you can only LIKE a post.
If you are logged in as any user - you can reply to a post and save the reply.

Note - when you are viewing the comment with replies - if you hover over the reply, you can see who and when the reply was done

There are a number of tests that are part of the system (There could be a lot more - but at least the principle of the tests is shown - including that if the system is ever refactored - the tests should STILL work!)

The 1 main issue (fought a bit with this but with the time limit - I stopped fighting for a solution and went with the MVP!) that I had with SQLite was that the auto increment identity was not available - so in tables that I could - I used the int and then used the guid(tostring()) for the rest - this causes problems for the postman scripts and you'll have to update the guids yourself
Changed the Tag id to a numeric string rather - and the user id to a numeric Id as well

And - when using the API for the Angular endpoints - I secured those using a Bearer token - and this is the Api Key: WebTextForumSecretKey!!@@=

I also made an extension method to convert the Entity objects to the View Model for returning to the calls - named ToDto() - to ensure the entities were not returned to the controllers

The paging in the Forum only happen after you have more than 5 items.

I took that Moderators were also allowed to create posts too - just like Users.

There is no sory on Like count, or search on tags and authors yet.

NOTE: I have tested and noticed that the paging - loses the searched for results and defaults to the unsearched for set.