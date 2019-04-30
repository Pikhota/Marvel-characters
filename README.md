# Marvel-characters

This mobile application loads data about Marvel Characters and their description, image etc. using Official Marvel API  https://developer.marvel.com/

# External libraries which i loaded using Nuget

Newtonsoft.json - this library needed to Deserialize data which i received using Marvel Api

Xam.Plugin.Connectivity - it's not a necessary library for this app, however i think that if this app need access Internet , i need to show some text on the screen if connection failed.

# A little bit about how i did it

I used MVVM architecture because this is best of practice to create mobile and desktop apps with opportunity  to scope,  support and testing through separates the user interface from the application logic.
I also have created a class MarvelService to work with Marvel API.

# Estimate

Include that is my first app on Xamarin and i needed to read the documentation and figure out how make navigation between page etc. The common time i spent to create this app about 8 hours
