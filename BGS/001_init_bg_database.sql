BEGIN;

CREATE TABLE public.boardgames (
	id int8 GENERATED ALWAYS AS IDENTITY NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT boardgames_pk PRIMARY KEY (id)
);

COMMIT;