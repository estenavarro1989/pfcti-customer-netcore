CREATE TABLE customer (
  id VARCHAR(50) PRIMARY KEY,
  first_name VARCHAR(20) NOT NULL,
  last_name VARCHAR(20),
  phone VARCHAR(20),
  birth_date DATE,
  created_at TIMESTAMP WITH TIME ZONE,
  updated_at TIMESTAMP WITH TIME ZONE
);

CREATE OR REPLACE PROCEDURE create_customer (
  p_id VARCHAR(50),
  p_first_name VARCHAR(20),
  p_last_name VARCHAR(20),
  p_phone VARCHAR(20),
  p_birth_date DATE
)
LANGUAGE plpgsql
AS $$
  BEGIN
    INSERT INTO customer VALUES(p_id, p_first_name, p_last_name, p_phone, p_birth_date, NOW());
    COMMIT;
  END;
$$;

CREATE OR REPLACE PROCEDURE update_customer (
  p_id VARCHAR(50),
  p_first_name VARCHAR(20),
  p_last_name VARCHAR(20),
  p_phone VARCHAR(20),
  p_birth_date DATE
)
LANGUAGE plpgsql
AS $$
  BEGIN
    UPDATE customer 
       SET first_name = p_first_name, 
           last_name = p_last_name, 
           phone = p_phone, 
           birth_date = p_birth_date,
	  	     updated_at = NOW()
     WHERE id = p_id;
    COMMIT;
  END;
$$;

CREATE OR REPLACE PROCEDURE delete_customer (
  p_id VARCHAR(50)
)
LANGUAGE plpgsql
AS $$
  BEGIN
    DELETE FROM customer WHERE id = p_id;
    COMMIT;
  END;
$$;

CREATE OR REPLACE PROCEDURE get_customers_order_by_birth_date_desc (
  INOUT p_result refcursor
)
LANGUAGE plpgsql
AS $$
  BEGIN
    OPEN p_result FOR SELECT id, first_name, last_name, phone, birth_date FROM customer ORDER BY birth_date DESC;
  END;
$$;

CREATE OR REPLACE PROCEDURE get_customers_order_by_id (
  INOUT p_result refcursor
)
LANGUAGE plpgsql
AS $$
  BEGIN
    OPEN p_result FOR SELECT id, first_name, last_name, phone, birth_date FROM customer ORDER BY id;
  END;
$$;

CREATE OR REPLACE PROCEDURE get_customers_order_by_name (
  INOUT p_result refcursor
)
LANGUAGE plpgsql
AS $$
  BEGIN
    OPEN p_result FOR SELECT id, first_name, last_name, phone, birth_date FROM customer ORDER BY first_name;
  END;
$$;

CREATE OR REPLACE PROCEDURE get_customer_by_id (
  IN p_id varchar,
  INOUT p_result refcursor
)
LANGUAGE plpgsql
AS $$
  BEGIN
    OPEN p_result FOR SELECT id, first_name, last_name, phone, birth_date FROM customer WHERE id = p_id;
  END;
$$;