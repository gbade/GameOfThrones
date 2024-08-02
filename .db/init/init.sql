CREATE EXTENSION IF NOT EXISTS dblink;

DO
$do$
BEGIN
   IF NOT EXISTS (
      SELECT FROM pg_catalog.pg_database
      WHERE datname = 'ASongOfIceAndFire'
   ) THEN
      PERFORM dblink_exec('dbname=postgres', 'CREATE DATABASE "ASongOfIceAndFire"');
   END IF;

   PERFORM dblink_exec('dbname=ASongOfIceAndFire', '
      CREATE TABLE IF NOT EXISTS Character (
         Id SERIAL PRIMARY KEY,
         CharacterName VARCHAR(100) NOT NULL,
         HouseName VARCHAR(100),
         Royal BOOLEAN,
         Parents TEXT[],  -- Using PostgreSQL array type for lists
         Siblings TEXT[],
         KilledBy TEXT[],
         Killed TEXT[],
         Nickname VARCHAR(100),
         CharacterImageThumb VARCHAR(255),q
         CharacterImageFull VARCHAR(255),
         CharacterLink VARCHAR(255),
         ActorName VARCHAR(100),
         ActorLink VARCHAR(255)
      );
   ');
END
$do$;