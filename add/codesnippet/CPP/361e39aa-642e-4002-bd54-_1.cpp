      m_MyServiceContainer->AddService( Control::typeid, gcnew ServiceCreatorCallback( this, &Form1::CreateNewControl ) );