import React, { useState, useEffect } from 'react';
import axios from 'axios';
import InputMask from 'react-input-mask';
import './RegisterForm.css';

const RegisterForm = () => {
    // Initialize state
    const [formData, setFormData] = useState({
        chineseName: '',
        firstName: '',
        lastName: '',
        sex: '',
        occupation: '',
        ageRangeID: '',
        phoneNumber: '',
        email: '',
        address: '',
        introducedBy: '',
        selectedLanguageIds: [],
        //birthPlace: '',
        responses: []
    });

    const [ageRanges, setAgeRanges] = useState([]);
    const [languages, setLanguages] = useState([]);
    const [questions, setQuestions] = useState([]);
    const [errors, setErrors] = useState({});
    const [message, setMessage] = useState('');

    useEffect(() => {
        fetchAgeRanges();
        fetchLanguages();
        fetchQuestions();
    }, []);

    const handleChange = (e) => {
        const { value, type, checked } = e.target;
        if (type === 'checkbox') {
            setFormData((prevData) => {
                const updatedIds = checked
                    ? [...prevData.selectedLanguageIds, String(value)]
                    : prevData.selectedLanguageIds.filter((lang) => lang !== String(value));

                return { ...prevData, selectedLanguageIds: updatedIds };
            });
        } else {
            setFormData((prevData) => ({ ...prevData, [e.target.name]: value }));
        }
    };

    const handleResponseChange = (e, qIndex) => {
        const { value } = e.target;
        setFormData((prevData) => {
            const updatedResponses = [...prevData.responses];
            updatedResponses[qIndex] = {
                ...updatedResponses[qIndex],
                ResponseId: String(value)
            };
            console.log("Updated Responses: ", updatedResponses)
            return { ...prevData, responses: updatedResponses };
        });
    };


    const fetchAgeRanges = async () => {
        axios.get('/ageranges')
            .then(response => {
                setAgeRanges(response.data);
            })
            .catch(error => {
                console.error('Error fetching age ranges:', error);
            });
    };

    const fetchLanguages = async () => {
        axios.get('/languages')
            .then(response => {
                setLanguages(response.data);
            })
            .catch(error => {
                console.error('Error fetching languages:', error);
            })
    }

    const fetchQuestions = async () => {
        axios.get('/questions')
            .then(response => {
                setQuestions(response.data);
            })
            .catch(error => {
                console.error('Error fetching questions:', error);
            })
    }

    // Validate the form
    const validate = () => {
        let tempErrors = {};
        if (!formData.chineseName) tempErrors.chineseName = "Chinese Name is required";
        if (!formData.sex) tempErrors.sex = "Sex is required";
        if (!formData.email) tempErrors.email = "Email is required";
        if (!formData.ageRangeID) tempErrors.ageRangeID = "Age is required";
        if (formData.selectedLanguageIds.length === 0) tempErrors.languages = "At least one language is required";
        if (!formData.reasonToVisit) tempErrors.reasonToVisit = "Please select a reason for your visit";
        if (!formData.relationWithGod) tempErrors.relationWithGod = "Please select a relationship with God";
        if (!formData.beVisited) tempErrors.beVisited = "Please select if you like to be visited";
        if (!formData.joinCellGroup) tempErrors.joinCellGroup = "Please select if you like to attend cell group meetings";
        if (!formData.phoneNumber) tempErrors.phoneNumber = "phoneNumber number is required";
        setErrors(tempErrors);
        return Object.keys(tempErrors).length === 0;
    };

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
//        if (validate()) {
        console.log("Form data submitted:", formData);
        axios.post('/Register', formData)
            .then(response => {
                if (response.data.success) {
                    console.log(response.data.message);
/*                        this.resetForm();*/
                } else {
                    errors = response.data.error || {};
                    console.log(errors);
                }
            })
            .catch(error => {
                console.error('Submission error:', errors);
                errors = (error.response && error.response.data && error.response.data.errors) || {};
                console.log("Error details:", errors)
            });
//        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Chinese Gospel Church New Friends Registration</h2>
            <hr /> {}
            <div className="question-row">Welcome to God's House. We hope the love of God flow along us by knowing and caring of you</div>
            <div className="form-row">
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Chinese Name:</label>
                        <input
                            type="text"
                            name="chineseName"
                            value={formData.chineseName}
                            onChange={handleChange}
                        />
                    </div>
                    {errors.chineseName && <p className="error-message">{errors.chineseName}</p>}
                </div>
                <div className="form-group">
                    <div className="form-group-row">
                        <label>First Name:</label>
                        <input
                            type="text"
                            name="firstName"
                            value={formData.firstName}
                            onChange={handleChange}
                        />
                    </div>
                    {errors.firstName && <p className="error-message">{errors.firstName}</p>}
                </div>
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Last Name:</label>
                        <input
                            type="text"
                            name="lastName"
                            value={formData.lastName}
                            onChange={handleChange}
                        />
                    </div>
                    {errors.lastName && <p className="error-message">{errors.lastName}</p>}
                </div>
            </div>
            <div className="form-row">
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Sex:</label>
                        <select name="sex" value={formData.sex} onChange={handleChange}>
                            <option value="">select your sex</option>
                            <option value="male">Male</option>
                            <option value="female">Female</option>
                        </select>
                    </div>
                    {errors.sex && <p className="error-message">{errors.sex}</p>}
                </div>
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Occupation:</label>
                        <input
                            type="text"
                            name="occupation"
                            value={formData.occupation}
                            onChange={handleChange}
                        />
                    </div>
                </div>
                <div className="form-group">
                    <div className="form-group-row">
                        <label htmlFor="ageRange">Age:</label>
                        <select
                            name="ageRangeID"
                            value={formData.ageRangeID}
                            onChange={handleChange}
                        >
                            <option value="">Select your age range</option>
                            {ageRanges.map(range => (
                                <option key={range.Id} value={range.Id}>
                                    {range.Range}
                                </option>
                            ))}
                        </select>
                    </div>
                    {errors.ageRangeID && <p className="error-message">{errors.ageRangeID}</p>}
                </div>
            </div>

            <div className="form-group">
                <div className="form-group-row">
                    <label>Languages:</label>
                    <div className="checkbox-group">
                        {languages.map((lang) => (
                            <label key={lang.Id}>
                                <input
                                    type="checkbox"
                                    name="selectedLanguageIds"
                                    value={String(lang.Id)}
                                    checked={formData.selectedLanguageIds.includes(String(lang.Id))}
                                    onChange={handleChange}
                                />
                                {lang.Name}
                            </label>
                        ))}
                    </div>
                    {errors.languages && <p className="error-message">{errors.languages}</p>}
                </div>
            </div>

            <div className="form-row">
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Address:</label>
                        <input
                            type="text"
                            name="address"
                            value={formData.address}
                            onChange={handleChange}
                            className="input-address"
                        />
                    </div>
                </div>
            </div>

            <div className="form-row">
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Phone Number:</label>
                        <InputMask
                            mask="(999) 999-9999"
                            name="phoneNumber"
                            value={formData.phoneNumber}
                            onChange={handleChange}
                        >
                            {(inputProps) => <input type="tel" {...inputProps} />}
                        </InputMask>
                    </div>
                    {errors.phoneNumber && <p className="error-message">{errors.phoneNumber}</p>}
                </div>
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Email:</label>
                        <input
                            type="email"
                            name="email"
                            value={formData.email}
                            onChange={handleChange}
                        />
                    </div>
                    {errors.email && <p className="error-message">{errors.email}</p>}
                </div>
            </div>

            <div className="form-row">
                {/*<div className="form-group">*/}
                {/*    <div className="form-group-row">*/}
                {/*        <label>Birth Place:</label>*/}
                {/*        <input*/}
                {/*            type="text"*/}
                {/*            name="birthPlace"*/}
                {/*            value={formData.birthPlace}*/}
                {/*            onChange={handleChange}*/}
                {/*        />*/}
                {/*    </div>*/}
                {/*</div>*/}
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Introduced By:</label>
                        <input
                            type="text"
                            name="introducedBy"
                            value={formData.introducedBy}
                            onChange={handleChange}
                        />
                    </div>
                </div>
            </div>

            <hr />


            <div className="form-group">
                {questions.map((question, qIndex) => (
                    <div key={question.QuestionId}>
                        <div className="question-row">{question.Question}</div>
                        <div className="radio-group">
                            {question.ResponseOptions.map((option) => (
                                <div key={option.Id} className="radio-item">
                                    <label>
                                        <input
                                            type="radio"
                                            name={`response_${qIndex}`}
                                            value={String(option.Id)}
                                            checked={formData.responses[qIndex]?.ResponseId === String(option.Id)}
                                            onChange={(e) => handleResponseChange(e, qIndex)}
                                        />
                                        {option.Response}
                                    </label>
                                </div>
                            ))}
                        </div>
                        {errors[`response_${qIndex}`] && <p className="error-message-radio">{errors[`response_${qIndex}`]}</p>}
                        <hr />
                    </div>
                ))}
            </div>


            <hr /> {}

            <button type="submit">Register</button>
            {message && <p>{message}</p>}
        </form>
    );
};

export default RegisterForm;