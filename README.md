# WSDL for ICalculatorService

This is a WSDL file defining a SOAP service for a simple calculator. The service provides an operation called "Add" that takes two integer inputs and returns the sum as an integer.

## WSDL Definition

```xml
<?xml version="1.0" encoding="utf-8"?> 
<definitions xmlns="http://schemas.xmlsoap.org/wsdl/"
             xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
             xmlns:tns="http://tempuri.org/"
             xmlns:xsd="http://www.w3.org/2001/XMLSchema"
             targetNamespace="http://tempuri.org/">

    <message name="AddRequest">
        <part name="a" type="xsd:int"/>
        <part name="b" type="xsd:int"/>
    </message>

    <message name="AddResponse">
        <part name="AddResult" type="xsd:int"/>
    </message>

    <portType name="ICalculatorService">
        <operation name="Add">
            <input message="tns:AddRequest"/>
            <output message="tns:AddResponse"/>
        </operation>
    </portType>

    <binding name="ICalculatorServiceSoap" type="tns:ICalculatorService">
        <soap:binding style="rpc" transport="http://schemas.xmlsoap.org/soap/http"/>
        <operation name="Add">
            <soap:operation soapAction="http://tempuri.org/Add"/>
            <input>
                <soap:body use="encoded" encodingStyle="http://schemas.xmlsoap.org/soap/encoding/" namespace="http://tempuri.org/"/>
            </input>
            <output>
                <soap:body use="encoded" encodingStyle="http://schemas.xmlsoap.org/soap/encoding/" namespace="http://tempuri.org/"/>
            </output>
        </operation>
    </binding>

    <service name="CalculatorService">
        <port name="ICalculatorServiceSoap" binding="tns:ICalculatorServiceSoap">
            <soap:address location="http://localhost:5000/CalculatorService.svc"/>
        </port>
    </service>
</definitions>
```

## Service Description

- **Service Name**: `CalculatorService`
- **Operation**: `Add`
  - **Input**: Two integers (`a`, `b`)
  - **Output**: The sum of the two integers (`AddResult`)

### SOAP Binding

- **Binding Style**: RPC (Remote Procedure Call)
- **SOAP Action**: `http://tempuri.org/Add`
- **Transport**: HTTP SOAP

### Service Endpoint

- **Service Location**: `http://localhost:5000/CalculatorService.svc`

This WSDL defines a simple SOAP service that can be used for adding two integers together using the provided `Add` operation.
