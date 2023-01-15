BEGIN TRANSACTION;

-- Drop tables if created

DROP TABLE IF EXISTS project_tickets;
DROP TABLE IF EXISTS ticket_investigators;
DROP TABLE IF EXISTS project_developers;
DROP TABLE IF EXISTS roles;
DROP TABLE IF EXISTS tickets;
DROP TABLE IF EXISTS statuses;
DROP TABLE IF EXISTS projects;
DROP TABLE IF EXISTS phases;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS positions;

-- Create tables

CREATE TABLE positions (
	position_id serial PRIMARY KEY,
	position_name varchar(32) NOT NULL
);

CREATE TABLE users (
    user_id serial PRIMARY KEY,
	position_id int REFERENCES positions(position_id),
    username varchar(16) NOT NULL UNIQUE,
	password_hash varchar(16) NOT NULL,
	salt varchar(16) NOT NULL
);

CREATE TABLE phases (
	phase_id serial PRIMARY KEY,
	phase_name varchar(16) NOT NULL
);

CREATE TABLE projects (
	project_id serial PRIMARY KEY,
	lead_id int REFERENCES users(user_id),
	phase_id int REFERENCES phases(phase_id),
	project_description varchar(256) NOT NULL
);

CREATE TABLE statuses (
	status_id serial PRIMARY KEY,
	status_name varchar(16) NOT NULL
);

CREATE TABLE tickets (
    ticket_id serial PRIMARY KEY,
	submitter_id int REFERENCES users(user_id),
	main_project_id int REFERENCES projects(project_id),
	status_id int REFERENCES statuses(status_id),
	ticket_description varchar(256) NOT NULL,
	priority int CHECK (priority >= 1 AND priority <= 3),
	submission_time timestamp
);

CREATE TABLE roles (
    role_id serial PRIMARY KEY,
	role_name varchar(16) NOT NULL
);

CREATE TABLE project_developers (
	project_id int REFERENCES projects(project_id),
	developer_id int REFERENCES users(user_id),
	developer_role_id int REFERENCES roles(role_id),
	CONSTRAINT project_developers_pk PRIMARY KEY (project_id, developer_id)
);

CREATE TABLE ticket_investigators (
	ticket_id int REFERENCES tickets(ticket_id),
	investigator_id int REFERENCES users(user_id),
	investigator_role_id int REFERENCES roles(role_id),
	CONSTRAINT ticket_investigators_pk PRIMARY KEY (ticket_id, investigator_id)
);

CREATE TABLE project_tickets (
	project_id int REFERENCES projects(project_id),
	ticket_id int REFERENCES tickets(ticket_id),
	CONSTRAINT project_tickets_pk PRIMARY KEY (project_id, ticket_id)
);

-- Insert values

INSERT INTO positions(position_name) VALUES ('Nemesis-Architect');
INSERT INTO positions(position_name) VALUES ('CTO');
INSERT INTO positions(position_name) VALUES ('Project-Lead');
INSERT INTO positions(position_name) VALUES ('Senior-Developer');
INSERT INTO positions(position_name) VALUES ('Junior-Developer');

INSERT INTO phases(phase_name) VALUES ('Genesis');
INSERT INTO phases(phase_name) VALUES ('Chrysalis');
INSERT INTO phases(phase_name) VALUES ('Aggregation');
INSERT INTO phases(phase_name) VALUES ('Ragnarok');

INSERT INTO statuses(status_name) VALUES ('Pending');
INSERT INTO statuses(status_name) VALUES ('Received');
INSERT INTO statuses(status_name) VALUES ('In-Progress');
INSERT INTO statuses(status_name) VALUES ('Resolved');
INSERT INTO statuses(status_name) VALUES ('Forsaken');

INSERT INTO roles(role_name) VALUES ('Principal');
INSERT INTO roles(role_name) VALUES ('Associate');

INSERT INTO users(position_id, username, password_hash, salt)
           VALUES(1, 'Maiven', 'password', 'saltysalt');
INSERT INTO users(position_id, username, password_hash, salt)
           VALUES(2, 'Thomas', 'password', 'saltysalt');
INSERT INTO users(position_id, username, password_hash, salt)
           VALUES(2, 'Hannah', 'password', 'saltysalt');
INSERT INTO users(position_id, username, password_hash, salt)
           VALUES(3, 'Anioah', 'password', 'saltysalt');

COMMIT;
