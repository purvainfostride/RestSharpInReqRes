Generic classes and methods- SPEC
json FILE IN .net
dynamic decide data type at runtime
status code

            //REQUEST
            var restClient = new RestClient("https://reqres.in/"); //creating var with RestClient method to pass base URL
            var restRequest = new RestRequest("/api/users?page=2", Method.GET); //passing end point & method of CRUD
            restRequest.AddHeader("Accept", "application/json"); //passing HEADERS
            restRequest.RequestFormat = DataFormat.Json; //FORMAT

            //RESPONSE
            var response = restClient.Execute(restRequest);   //Handling response with interface by executing request
            //getting content
            var content = response.Content;

            //Deserialization  (Convert JSON -> .NET)
            var users = JsonConvert.DeserializeObject<GetListOfUsersDTO>(content);
            return users;
