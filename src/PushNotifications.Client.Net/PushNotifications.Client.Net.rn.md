#### 5.1.2 - 26.11.2018
* Removes RestSharpIdentityModelExtensions

#### 5.0.2 - 07.08.2018
* Fixes TopicSubscribeModel

#### 5.0.1 - 07.08.2018
* Adds endpoint to get topic subscription count

#### 5.0.0 - 26.07.2018
* Changes the public interface for the topic subscription

#### 4.1.0 - 25.07.2018
* Adds endpoints for topic subscription
* Adds endpoints for sending push notifications to a topic

#### 4.0.0 - 13.04.2018
* Moved to a separate repository

#### 3.2.0 - 05.04.2018
* Adds a check for the number of tokens which will receive pushnotification. FireBase has a limit of 1000 per request
* Removes ContentAvailable which makes the pushnotification to be a silent pushnotification. Apple/Google throttle or drop some of those when there are many sent to a device because it may drain battery on the device. Instead we use the `priority` set to `high`.
* Sets default badge to be `1`

#### 3.1.0 - 27.03.2018
* Fixes nuget package IDs

#### 3.0.0 - 11.12.2017
* Adds notification data support
* Removes requirement for title and body when sending push notification
* Fixes issue where is success property was false all the time
* Adds normalized discovery
* Accepts datetime instead of timestamp when sending pn
* Initial release for version 3 of pn
