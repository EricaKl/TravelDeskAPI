import React, {useState, useEffect} from 'react';
import { useFormik } from 'formik';
import * as Yup from 'yup';

const NewTravelRequest = () => {
    const [showBookingOptions, setShowBookingOptions] = useState(false);
    const [showFromDateOptions, setShowFromDateOptions] = useState(false);
    const [showDaysOfStayOptions, setShowDaysOfStayOptions] = useState(false);
    const [showDomesticOptions, setShowDomesticOptions] = useState(false);
    const [showInternationalOptions, setShowInternationalOptions] = useState(false);
    const [showMealsReqOptions, setShowMealsReqOptions] = useState(false);
    const [showMealsPrefOptions, setShowMealsPrefOptions] = useState(false);
    const [showCountryOptions, setShowCountryOptions] = useState(false);
    const [showCityOptions, setShowCityOptions] = useState(false);

    const[projects, setProjects] = useState([]);
    const[bookingName, setBookingTypes] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {

        fetch('http://localhost:21384/api/Request/GetProjects')
            .then(response => response.json())
            .then(data => {
                setProjects(data);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching projects:', error);
                setLoading(false);
            });

            fetch('http://localhost:21384/api/Request/GetBookingTypes')
            .then(response => response.json())
            .then(data => {
                setBookingTypes(data);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching projects:', error);
                setLoading(false);
            });
        },[])

    const formik = useFormik({
        initialValues: {
            employeeID:'',
            employeeName: '',
            projectId:'',
            departmentId:'',
            reasonForTravelling:'',
            bookingTypeId :'',
            aadharCard:'',
            fromDate:'',
            toDate:'',
            passportNumber : '',
            passportFile : '',
            visaFile:'',
            daysOfStay:'',
            mealId:'',
            mealPrefId:'',
        },
        validationSchema: Yup.object({
            // name: Yup.string()
            //     .required('Name is required'),
            // dropdownValue: Yup.string()
            //     .required('Dropdown value is required'),
            // file: Yup.mixed()
            //     .required('File is required')
        }),
        onSubmit: values => {
            // Handle form submission logic here
            console.log(values);
        },
    });

    const handleBookingTypeChange = (event) => {
        if (event.target.value === '1' ){
            
            setShowFromDateOptions(false);
            setShowDaysOfStayOptions(false);
            setShowMealsReqOptions(false);
            setShowMealsPrefOptions(false);
            setShowBookingOptions(true);
            setShowCountryOptions(true);
            setShowCityOptions(true);
        }
        else if (event.target.value === '2' ){
            setShowBookingOptions(false);
            setShowDomesticOptions(false);
            setShowInternationalOptions(false);
            setShowFromDateOptions(true);
            setShowDaysOfStayOptions(true);
            setShowMealsReqOptions(true);
            setShowMealsPrefOptions(true);
            setShowCountryOptions(true);
            setShowCityOptions(true);
        } 
        else if (event.target.value === '3' ){
            setShowBookingOptions(true);
            setShowDomesticOptions(true);
            setShowInternationalOptions(true);
            setShowFromDateOptions(false);
            setShowDaysOfStayOptions(true);
            setShowMealsReqOptions(true);
            setShowMealsPrefOptions(true);
            setShowCountryOptions(true);
            setShowCityOptions(true);
        }else {
            setShowBookingOptions(false);
        }
        formik.handleChange(event); // Update formik state
    };
    const handleFlightTypeChange = (event) => {
        if (event.target.value === '1' ){
            setShowInternationalOptions(false);
            setShowDomesticOptions(true);
            setShowFromDateOptions(false);
            // setShowAadharOptions(true);
            // setShowFromDateOptions(true);
            // setShowToDateOptions(true);
        }
        else if (event.target.value === '2' ){
            
            setShowDomesticOptions(false);
            setShowInternationalOptions(true);
            setShowFromDateOptions(false);
            // setShowAadharOptions(true);
            // setShowFromDateOptions(true);
            // setShowToDateOptions(true);
        } else {
            
            setShowInternationalOptions(false);
        }
        formik.handleChange(event); // Update formik state
    };


    return (
        <div>
            <h2>New Travel Request</h2>
            <form onSubmit={formik.handleSubmit}>
                <div className="form-group">
                    <label htmlFor="employeeID">Employee ID</label>
                    <input
                        type="text"
                        id="employeeID"
                        name="employeeID"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.employeeID}
                    />
                    {formik.touched.employeeID && formik.errors.employeeID ? (
                        <div className="error">{formik.errors.employeeID}</div>
                    ) : null}
                </div>

                <div className="form-group">
                    <label htmlFor="employeeName">Employee Name</label>
                    <input
                        type="text"
                        id="employeeName"
                        name="employeeName"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.employeeName}
                    />
                    {formik.touched.employeeName && formik.errors.employeeName ? (
                        <div className="error">{formik.errors.employeeName}</div>
                    ) : null}
                </div>

                <div className="form-group">
                    <label htmlFor="projectId">Project Name</label>
                    <select
                        id="projectId"
                        name="projectId"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.projectId}
                    >
                        <option value="" label="Select Project" />
                            {loading ? (
                                <option value="" label="Loading..." />
                            ) : (
                                projects.map(project => (
                                    <option key={project.clientID} value={project.projectID}
                                     label={project.projectName} />
                                ))
                            )}
                    </select>
                    {formik.touched.projectId && formik.errors.projectId ? (
                        <div className="error">{formik.errors.projectId}</div>
                    ) : null}
                </div>

                <div className="form-group">
                    <label htmlFor="departmentId">Department Name</label>
                    <select
                        id="departmentId"
                        name="departmentId"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.departmentId}
                    >
                        <option value="">Select an option</option>
                        {/* Add options for your dropdown */}
                    </select>
                    {formik.touched.departmentId && formik.errors.departmentId ? (
                        <div className="error">{formik.errors.departmentId}</div>
                    ) : null}
                </div>

                <div className="form-group">
                    <label htmlFor="reasonForTravelling">Reason For Travelling</label>
                    <input
                        type="text"
                        id="reasonForTravelling"
                        name="reasonForTravelling"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.reasonForTravelling}
                    />
                    {formik.touched.reasonForTravelling && formik.errors.reasonForTravelling ? (
                        <div className="error">{formik.errors.reasonForTravelling}</div>
                    ) : null}
                </div>

                {/* 
                <div className="form-group">
                    <label htmlFor="departmentId">Department Name</label>
                    <select
                        id="departmentId"
                        name="departmentId"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.departmentId}
                    >
                        <option value="">Select an option</option>
                       
                    </select>
                    {formik.touched.departmentId && formik.errors.departmentId ? (
                        <div className="error">{formik.errors.departmentId}</div>
                    ) : null}
                </div> */}


                <div className="form-group">
                    <label htmlFor="bookingTypeId">Type of Booking</label>
                    <select
                        id="bookingTypeId"
                        name="bookingTypeId"
                        className="form-control"
                        // onChange={formik.handleChange}
                        onChange={handleBookingTypeChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.bookingTypeId}
                    >
                        <option value="" label="Select Booking Type" />
                            {loading ? (
                                <option value="" label="Loading..." />
                            ) : (
                                bookingName.map(bookingType => (
                                    <option key={bookingType.bookingTypeID} value={bookingType.bookingTypeId}
                                     label={bookingType.bookingTypes} />
                                ))
                            )}
                    
                    </select>
                    {formik.touched.bookingTypeId && formik.errors.bookingTypeId ? (
                        <div className="error">{formik.errors.bookingTypeId}</div>
                    ) : null}
                </div>

                {showBookingOptions && (
                    <div className="form-group">
                      <label htmlFor="flightTypeId">Type of Flight</label>
                    <select
                        id="flightTypeId"
                        name="flightTypeId"
                        className="form-control"
                        // onChange={formik.handleChange}
                        onChange={handleFlightTypeChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.flightTypeId}
                    >
                        <option value="">Select an option</option>
                        <option value = "1">Domestic Flight</option>
                        <option value = "2">International Flight</option>
                    
                    </select>
                        
                        {formik.touched.flightTypeId && formik.errors.flightTypeId ? (
                            <div className="error">{formik.errors.flightTypeId}</div>
                        ) : null}
                    </div>
                    
                )}

                {showDomesticOptions && (
                    <div className="form-group">
                        <label htmlFor="aadharCard">Aadhar Card</label>
                        <input
                            type="text"
                            id="aadharCard"
                            name="aadharCard"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.aadharCard}
                        />
                         
                        
                        {formik.touched.aadharCard && formik.errors.aadharCard ? (
                            <div className="error">{formik.errors.aadharCard}</div>
                        ) : null}
                    </div>
                    
                )}

                {showDomesticOptions && (
                    <div className="form-group">
                        <label htmlFor="fromDate">From Date</label>
                        <input
                            type="date"
                            id="fromDate"
                            name="fromDate"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.fromDate}
                        />
                         
                        
                        {formik.touched.fromDate && formik.errors.fromDate ? (
                            <div className="error">{formik.errors.fromDate}</div>
                        ) : null}
                    </div>
                    
                )}

                {showDomesticOptions && (
                    <div className="form-group">
                        <label htmlFor="toDate">To Date</label>
                        <input
                            type="date"
                            id="toDate"
                            name="toDate"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.toDate}
                        />
                         
                        
                        {formik.touched.toDate && formik.errors.toDate ? (
                            <div className="error">{formik.errors.toDate}</div>
                        ) : null}
                    </div>
                    
                )}

                {showCountryOptions && (
                    <div className="form-group">
                        <label htmlFor="flightCountryId">Country</label>
                        <select
                        id="flightCountryId"
                        name="flightCountryId"
                        className="form-control"
                        onChange={formik.handleChange}
                        //onChange={handleFlightTypeChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.flightCountryId}
                    >
                        <option value="">Select an option</option>
                        <option value = "1">India</option>
                        <option value = "2">UK</option>
                    
                    </select>
                         
                        
                        {formik.touched.flightCountryId && formik.errors.flightCountryId ? (
                            <div className="error">{formik.errors.flightCountryId}</div>
                        ) : null}
                    </div>
                    
                )}

                {showCityOptions && (
                    <div className="form-group">
                        <label htmlFor="flightCityId">City</label>
                        <select
                        id="flightCityId"
                        name="flightCityId"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.flightCityId}
                    >
                        <option value="">Select an option</option>
                        <option value = "1">Pune</option>
                        <option value = "2">Hyderabad</option>
                        <option value = "3">Malta</option>
                        <option value = "4">Dubai</option>
                    
                    </select>
                         
                        
                        {formik.touched.flightCityId && formik.errors.flightCityId ? (
                            <div className="error">{formik.errors.flightCityId}</div>
                        ) : null}
                    </div>
                    
                )}

                {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="passportNumber">Passport Number</label>
                        <input
                            type="text"
                            id="passportNumber"
                            name="passportNumber"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.passportNumber}
                        />
                         
                        
                        {formik.touched.passportNumber && formik.errors.passportNumber ? (
                            <div className="error">{formik.errors.passportNumber}</div>
                        ) : null}
                    </div>
                    
                )}
                    {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="aadharCard">Aadhar Card</label>
                        <input
                            type="text"
                            id="aadharCard"
                            name="aadharCard"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.aadharCard}
                        />
                         
                        
                        {formik.touched.aadharCard && formik.errors.aadharCard ? (
                            <div className="error">{formik.errors.aadharCard}</div>
                        ) : null}
                    </div>
                    
                )}

                {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="fromDate">From Date</label>
                        <input
                            type="date"
                            id="fromDate"
                            name="fromDate"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.fromDate}
                        />
                         
                        
                        {formik.touched.fromDate && formik.errors.fromDate ? (
                            <div className="error">{formik.errors.fromDate}</div>
                        ) : null}
                    </div>
                    
                )}

                {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="toDate">To Date</label>
                        <input
                            type="date"
                            id="toDate"
                            name="toDate"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.toDate}
                        />
                         
                        
                        {formik.touched.toDate && formik.errors.toDate ? (
                            <div className="error">{formik.errors.toDate}</div>
                        ) : null}
                    </div>
                    
                )}


                {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="passportFile">Upload Passport File</label>
                    <input
                        type="file"
                        id="passportFile"
                        name="passportFile"
                        className="form-control-file"
                        onChange={(event) => {
                            formik.setFieldValue("passportFile", event.currentTarget.files[0]);
                        }}
                    />
                    {formik.touched.passportFile && formik.errors.passportFile ? (
                        <div className="error">{formik.errors.passportFile}</div>
                    ) : null}
                    </div>
                    
                )}

                {showInternationalOptions && (
                    <div className="form-group">
                        <label htmlFor="visaFile">Upload Visa File</label>
                    <input
                        type="file"
                        id="visaFile"
                        name="visaFile"
                        className="form-control-file"
                        onChange={(event) => {
                            formik.setFieldValue("visaFile", event.currentTarget.files[0]);
                        }}
                    />
                    {formik.touched.visaFile && formik.errors.visaFile ? (
                        <div className="error">{formik.errors.visaFile}</div>
                    ) : null}
                    </div>
                    
                )}

                {showDaysOfStayOptions && (
                    <div className="form-group">
                        <label htmlFor="daysOfStay">Staying Days</label>
                    <input
                        type="number"
                        id="daysOfStay"
                        name="daysOfStay"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.daysOfStay}
                       
                    />
                    {formik.touched.daysOfStay && formik.errors.daysOfStay ? (
                        <div className="error">{formik.errors.daysOfStay}</div>
                    ) : null}
                    </div>
                    
                )}


                {showFromDateOptions && (
                    <div className="form-group">
                        <label htmlFor="fromDate">From Date</label>
                        <input
                            type="date"
                            id="fromDate"
                            name="fromDate"
                            className="form-control"
                            onChange={formik.handleChange}
                            onBlur={formik.handleBlur}
                            value={formik.values.fromDate}
                        />
                         
                        
                        {formik.touched.fromDate && formik.errors.fromDate ? (
                            <div className="error">{formik.errors.fromDate}</div>
                        ) : null}
                    </div>
                    
                )}

                {showMealsReqOptions && (
                    <div className="form-group">
                      <label htmlFor="mealId">Meal Required</label>
                    <select
                        id="mealId"
                        name="mealId"
                        className="form-control"
                        // onChange={formik.handleChange}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.mealId}
                    >
                        <option value="">Select an option</option>
                        <option value = "1">Lunch</option>
                        <option value = "2">Dinner</option>
                        <option value = "3">Both</option>
                    
                    </select>
                        
                        {formik.touched.mealId && formik.errors.mealId ? (
                            <div className="error">{formik.errors.mealId}</div>
                        ) : null}
                    </div>
                    
                )}

                {showMealsPrefOptions && (
                    <div className="form-group">
                      <label htmlFor="mealPrefId">Meal Preference</label>
                    <select
                        id="mealPrefId"
                        name="mealPrefId"
                        className="form-control"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.mealPrefId}
                    >
                        <option value="">Select an option</option>
                        <option value = "1">Veg</option>
                        <option value = "2">Non-Veg</option>
                    
                    </select>
                        
                        {formik.touched.mealPrefId && formik.errors.mealPrefId ? (
                            <div className="error">{formik.errors.mealPrefId}</div>
                        ) : null}
                    </div>
                    
                )}

                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        </div>
    );
}

export default NewTravelRequest;
