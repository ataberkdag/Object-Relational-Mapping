from sqlalchemy import Column, Integer, String
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy import create_engine

Base = declarative_base()

class Kullanıcı(Base):
    __tablename__ = "KullanıcıTablosu"

    id = Column(Integer, primary_key = True)
    Name = Column(String(250), nullable = False)
    Surname = Column(String(250), nullable = False)

engine = create_engine("sqlite:///Kullanıcılar.db")

Base.metadata.create_all(engine)
