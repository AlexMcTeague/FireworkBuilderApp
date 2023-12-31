# FireworkBuilderApp

## Summary

**NOTE: This app contains flickering lights and may not be suitable for those with photosensitive epilepsy**

This app allows you to build and display Fireworks of your choosing, by combining several pieces. Currently these pieces are:
* The Rocket, which determines how fast and high the firework flies.
* The Payload, which determines the shape, color, and size of the explosion. Each Firework can have multiple Payloads, which allows you to get creative with combinations.

## Installation

**NOTE: This app requires Windows**

This is because it relies on WinForms for its GUI, which is Windows-only.

To install, simply clone the repo into a new Visual Studio solution and hit Run.

The database should be created automatically along with some seeded data, and you should see a sample firework show begin to play.

## Usage

This app is split into three windows:

### Main Display Window

![Main display screen](https://i.imgur.com/I4U4dja.png)

This is where you'll see your fireworks in action. Once selected, fireworks will launch in a continuous loop; after they explode, the particles will last for a few seconds, and when they're gone the firework will be re-launched.

You can select a new firework to preview using the Quick Preview dropdown at the top of the window. This should list all the fireworks in the database.

Note that currently you can only Quick Preview one firework at a time. I plan to add the ability to select multiple fireworks to launch at once, similar to how three are displayed when first opening the app.

### Console Window

The console window is mostly a by-product of earlier versions of the app, however it does still display error logs when you attempt to add incorrect data via the Add menus.

Closing the console also closes the display window (and therefore the whole app).

### "Add _____" Windows

![Add _____ Windows](https://i.imgur.com/2AEQAre.png)

The third window is an optional one. It will appear if you use any of the "Add -> Add _____" dropdowns at the top of the window.

Simply fill out the details as suggested by the window, and hit Save. If your values were accepted, the window will close, otherwise an error will be printed in the console.

While there are several error checks, I wouldn't try *too* hard to find a loophole, or you may risk a crash.

It's possible to open up multiple Add Forms at the same time, but doing that may impact performance.

Note that the "Remove" and "Edit" tools are a work in progress, so think carefully before saving your Firework.

I plan to add the ability to preview Rockets and Payloads independently, and the ability to preview them from the Add menu (rather than needing to save and build a firework before checking how they look).

## Code Notes

**NOTE: To view code inside Form classes, right click them and select "View Code"** (double-clicking will open the Design View instead)

### Requirements

This project meets the following requirements for Code Louisville:
* "Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program."

This app populates / retrieves from several Lists. For a good example, see "List<FireworkVisual> visuals" in DrawForm.cs. The List is populated with AddFireworkVisual() and used by the OnPaint event handler.

* "Query your database using a raw SQL query, not EF"

An example of this can be seen on line 26 of DrawForm.cs. Unfortunately Raw SQL has many limitations when it comes to many-to-many relationships, .Include

* Make your application asynchronous

Where possible, this app uses SaveChangesAsync and AddAsync instead of SaveChanges and Add
