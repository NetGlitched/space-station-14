﻿#nullable enable
using System.Diagnostics.CodeAnalysis;
using Content.Server.GameObjects.EntitySystems;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;

namespace Content.Server.Atmos
{
    public static class AtmosHelpers
    {
        public static TileAtmosphere? GetTileAtmosphere(this EntityCoordinates coordinates, IEntityManager? entityManager = null)
        {
            entityManager ??= IoCManager.Resolve<IEntityManager>();

            var gridAtmos = EntitySystem.Get<AtmosphereSystem>().GetGridAtmosphere(coordinates.GetGridId(entityManager));

            return gridAtmos?.GetTile(coordinates);
        }

        public static GasMixture? GetTileAir(this EntityCoordinates coordinates, IEntityManager? entityManager = null)
        {
            return coordinates.GetTileAtmosphere(entityManager)?.Air;
        }

        public static bool TryGetTileAtmosphere(this EntityCoordinates coordinates, [MaybeNullWhen(false)] out TileAtmosphere atmosphere)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return !Equals(atmosphere = coordinates.GetTileAtmosphere()!, default);
        }

        public static bool TryGetTileAir(this EntityCoordinates coordinates, [MaybeNullWhen(false)] out GasMixture air, IEntityManager? entityManager = null)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return !Equals(air = coordinates.GetTileAir(entityManager)!, default);
        }

        public static TileAtmosphere? GetTileAtmosphere(this Vector2i indices, GridId gridId)
        {
            var gridAtmos = EntitySystem.Get<AtmosphereSystem>().GetGridAtmosphere(gridId);

            return gridAtmos?.GetTile(indices);
        }

        public static GasMixture? GetTileAir(this Vector2i indices, GridId gridId)
        {
            return indices.GetTileAtmosphere(gridId)?.Air;
        }

        public static bool TryGetTileAtmosphere(this Vector2i indices, GridId gridId,
            [MaybeNullWhen(false)] out TileAtmosphere atmosphere)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return !Equals(atmosphere = indices.GetTileAtmosphere(gridId)!, default);
        }

        public static bool TryGetTileAir(this Vector2i indices, GridId gridId, [MaybeNullWhen(false)] out GasMixture air)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return !Equals(air = indices.GetTileAir(gridId)!, default);
        }
    }
}
