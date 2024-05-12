namespace MovieAppApi.Exceptions;

using System;

public class RequestException(string message) : Exception(message) {}