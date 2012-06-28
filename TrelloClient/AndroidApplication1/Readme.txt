*** Trello client for Android w/ Mono (Read-Only) ***

3rd party references:
* RestSharp 103.00 for MonoDroid. (Included in Solution's root folder)

Custom Folders explanation:

* Delegates: contains the delegates used by Trello's OAuthentication class.
* Handlers: with handlers I mean the classes which provide the responsability of getting data from Trello's API such as List, Boards, Cards and so on. With this approach I tried to accomplish the single responsability principle -SRP.          TrelloOAuthExtensions.cs class provides a set of extension methods in order to make it easier. GetData.cs and GetListData.cs are nested typed interfaces, which each handler should implement.
* Misc:     Data and notes for me. Not included as content.
* Model:    POCO classes used as a representation of the Trello's API. 
* Utils:    There are a couple of classes. Network.cs provides some kind of network functionality to check whether there is or isn't Internet connection. TrelloOAuth.cs is the core class provider for Trello API.
* Views:    This folder contains all the classes used for providing custom Adapters for ListActivity based classes.
* \:        Root folder: Activities.

Notes:

* The project has been entirely developed w/ VS2010 and debugged with MonoDevelop 3.0 on MacOSX.