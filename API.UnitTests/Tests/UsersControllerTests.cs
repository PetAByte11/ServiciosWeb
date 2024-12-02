namespace API.UnitTests.Tests;

using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using API.DTOs;
using API.UnitTests.Helpers;
using Newtonsoft.Json.Linq;
using Xunit;

public class UsersControllerTests
{
    private readonly string apiRoute = "api/users";
    private readonly HttpClient _client;
    private HttpResponseMessage httpResponse;
    private string requestUrl;
    private string loginObject;
    private HttpContent httpContent;

    public UsersControllerTests() => _client = TestHelper.Instance.Client;

    [Fact]
    public async Task GetByUsernameAsync_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        // Arrange: Login para obtener el token
        var loginRequest = new LoginRequest
        {
            Username = "arenita",
            Password = "123456"
        };

        requestUrl = "api/account/login";
        loginObject = GetLoginObject(loginRequest);
        httpContent = GetHttpContent(loginObject);

        httpResponse = await _client.PostAsync(requestUrl, httpContent);
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResponse.Token);

        // Act
        var nonExistentUsername = "nonexistentuser";
        requestUrl = $"{apiRoute}/{nonExistentUsername}";
        httpResponse = await _client.GetAsync(requestUrl);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
    }

    [Fact]
    public async Task GetByUsernameAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "arenita", // Usuario semilla existente
            Password = "123456"
        };

        requestUrl = "api/account/login";
        loginObject = GetLoginObject(loginRequest);
        httpContent = GetHttpContent(loginObject);

        httpResponse = await _client.PostAsync(requestUrl, httpContent);
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(userResponse);
        Assert.NotNull(userResponse.Token);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResponse.Token);

        var existingUsername = "arenita";
        requestUrl = $"{apiRoute}/{existingUsername}";
        httpResponse = await _client.GetAsync(requestUrl);

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        var member = await httpResponse.Content.ReadFromJsonAsync<MemberResponse>();
        Assert.NotNull(member);
        Assert.Equal(existingUsername, member.UserName);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfUsers_WhenUsersExist()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "arenita", 
            Password = "123456"
        };

        requestUrl = "api/account/login";
        loginObject = GetLoginObject(loginRequest);
        httpContent = GetHttpContent(loginObject);

        httpResponse = await _client.PostAsync(requestUrl, httpContent);
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(userResponse);
        Assert.NotNull(userResponse.Token);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResponse.Token);

        // Act
        requestUrl = apiRoute; // Usa la ruta base definida para "api/users"
        httpResponse = await _client.GetAsync(requestUrl);

        // Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        var members = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<MemberResponse>>();
        Assert.NotNull(members);
        Assert.True(members.Any(), "La lista de usuarios debería contener al menos un elemento.");
    }

    [Fact]
    public async Task UpdateUser_ShouldUpdateSuccessfully_WhenRequestIsValid()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "arenita", // Usuario existente en la base de datos semilla
            Password = "123456"
        };

        requestUrl = "api/account/login";
        loginObject = GetLoginObject(loginRequest);
        httpContent = GetHttpContent(loginObject);

        httpResponse = await _client.PostAsync(requestUrl, httpContent);
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var userResponse = JsonSerializer.Deserialize<UserResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(userResponse);
        Assert.NotNull(userResponse.Token);

        // Configura el token en las cabeceras
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userResponse.Token);

        // Act
        var updateRequest = new MemberUpdateRequest
        {
            Introduction = "Hola, soy Arenita y he actualizado mi perfil.",
            LookingFor = "Alguien para practicar karate",
            Interests = "Karate, ciencia, vida marina",
            City = "Fondo de Bikini",
            Country = "Océano Pacífico"
        };

        requestUrl = "api/users";
        httpContent = GetHttpContent(JsonSerializer.Serialize(updateRequest));

        httpResponse = await _client.PutAsync(requestUrl, httpContent);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);

        // Act
        requestUrl = $"{apiRoute}/arenita"; // Verifica el usuario actualizado
        httpResponse = await _client.GetAsync(requestUrl);

        // Assert
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        var updatedMember = await httpResponse.Content.ReadFromJsonAsync<MemberResponse>();

        Assert.NotNull(updatedMember);
        Assert.Equal(updateRequest.Introduction, updatedMember.Introducction);
        Assert.Equal(updateRequest.LookingFor, updatedMember.LookingFor);
        Assert.Equal(updateRequest.Interests, updatedMember.Interests);
        Assert.Equal(updateRequest.City, updatedMember.City);
        Assert.Equal(updateRequest.Country, updatedMember.Country);
    }

    #region Métodos privados auxiliares

    private static string GetLoginObject(LoginRequest loginDto)
    {
        var entityObject = new JObject()
            {
                { nameof(loginDto.Username), loginDto.Username },
                { nameof(loginDto.Password), loginDto.Password }
            };

        return entityObject.ToString();
    }

    private static StringContent GetHttpContent(string objectToCode) =>
        new(objectToCode, Encoding.UTF8, "application/json");

    #endregion
}
