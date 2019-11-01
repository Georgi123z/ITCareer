-- 209. Изтеглете най-бързия космически кораб
USE colonial_journey_management_system_db;

SELECT sh.name AS spaceship_name, sp.name AS spaceport_name
FROM spaceships AS sh
JOIN journeys AS j ON sh.id = j.spaceship_id
JOIN spaceports AS sp ON sp.id = j.destination_spaceport_id
ORDER BY sh.light_speed_rate DESC
LIMIT 1;