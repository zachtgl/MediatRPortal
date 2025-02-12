﻿using MediatRPortal.Client.Models;

namespace MediatRPortal.Client.Services;

public class RouteService
{
    private readonly List<Route> _routes = [];
    public IReadOnlyList<Route> Routes => _routes;

    public Guid AddRoute(string origin, string destination, string currency)
    {
        var id = Guid.NewGuid();

        _routes.Add(new Route
        {
            Id = id,
            Origin = origin,
            Destination = destination,
            Currency = currency
        });

        return id;
    }

    public void RemoveRoute(Guid routeId)
    {
        var route = _routes.FirstOrDefault(r => r.Id == routeId);
        if (route is not null)
        {
            _routes.Remove(route);
        }
    }

    public void UpdateRoute(Guid routeId, string origin, string destination, string currency)
    {
        var route = _routes.FirstOrDefault(r => r.Id == routeId);
        if (route is not null)
        {
            route.Origin = origin;
            route.Destination = destination;
            route.Currency = currency;
        }
    }

    public Route? GetRoute(Guid routeId)
    {
        return _routes.FirstOrDefault(r => r.Id == routeId);
    }
}
