import React, { useState } from 'react';
import axios from 'axios';
import InputMask from 'react-input-mask';
import './RegisterForm.css';

const RegisterForm = () => {
    // Initialize state
    const [formData, setFormData] = useState({
        chineseName: '',
        englishName: '',
        sex: '',
        occupation: '',
        age: '',
        languages: [],
        address: '',
        telephone: '',
        email: '',
        birthPlace: '',
        introducedBy: '',
        reasonToVisit: '',
        relationWithGod: '',
        beVisited: '',
        joinCellGroup: ''
    });

    const [errors, setErrors] = useState({});
    const [message, setMessage] = useState('');

    // Handle input change
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        if (type === 'checkbox') {
            if (checked) {
                setFormData((prevData) => ({
                    ...prevData,
                    languages: [...prevData.languages, value]
                }));
            } else {
                setFormData((prevData) => ({
                    ...prevData,
                    languages: prevData.languages.filter((lang) => lang !== value)
                }));
            }
        }
        else if (type === 'radio') {
            setFormData({
                ...formData,
                [name]: value
            });
        } else {
            setFormData({
                ...formData,
                [name]: value
            });
        }
    };

    // Validate the form
    const validate = () => {
        let tempErrors = {};
        if (!formData.chineseName) tempErrors.chineseName = "Chinese Name is required";
        if (!formData.sex) tempErrors.sex = "Sex is required";
        if (!formData.email) tempErrors.email = "Email is required";
        if (!formData.age) tempErrors.age = "Age is required";
        if (formData.languages.length === 0) tempErrors.languages = "At least one language is required";
        if (!formData.reasonToVisit) tempErrors.reasonToVisit = "Please select a reason for your visit";
        if (!formData.relationWithGod) tempErrors.relationWithGod = "Please select a relationship with God";
        if (!formData.beVisited) tempErrors.beVisited = "Please select if you like to be visited";
        if (!formData.joinCellGroup) tempErrors.joinCellGroup = "Please select if you like to attend cell group meetings";
        if (!formData.telephone) tempErrors.telephone = "Telephone number is required";
        setErrors(tempErrors);
        return Object.keys(tempErrors).length === 0;
    };

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        if (validate()) {
            console.log("Form data submitted:", formData);
            // Perform registration logic here
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Chinese Gospel Church New Friends Registration</h2>
            <hr /> {/* Add a horizontal line to start a new section */}
            <div className="question-row">Welcom to God's House. We hope the love of God flow along us by knowing and caring of you</div>
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
                        <label>English Name:</label>
                        <input
                            type="text"
                            name="englishName"
                            value={formData.englishName}
                            onChange={handleChange}
                        />
                    </div>
                    {errors.englishName && <p className="error-message">{errors.englishName}</p>}
                </div>
            </div>
            <div className="form-row">
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Sex:</label>
                        <select name="sex" value={formData.sex} onChange={handleChange}>
                            <option value="">select your sex</option>
                            <option value="male">male</option>
                            <option value="female">female</option>
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
                        <label>Age:</label>
                        <select name="age" value={formData.age} onChange={handleChange}>
                            <option value="">select your age range</option>
                            <option value="under 20">Under 20</option>
                            <option value="21-30">21-30</option>
                            <option value="31-40">31-40</option>
                            <option value="41-55">41-55</option>
                            <option value="56 and above">56 and above</option>
                        </select>
                    </div>
                    {errors.age && <p className="error-message">{errors.age}</p>}
                </div>
            </div>

            <div className="form-group">
                <div className="form-group-row">
                    <label>Languages:</label>
                    <div className="checkbox-group">
                        <label>
                            <input
                                type="checkbox"
                                name="languages"
                                value="English"
                                checked={formData.languages.includes('English')}
                                onChange={handleChange}
                            />
                            English
                        </label>
                        <label>
                            <input
                                type="checkbox"
                                name="languages"
                                value="Chinese"
                                checked={formData.languages.includes('Chinese')}
                                onChange={handleChange}
                            />
                            Chinese
                        </label>
                        <label>
                            <input
                                type="checkbox"
                                name="languages"
                                value="Cantonese"
                                checked={formData.languages.includes('Cantonese')}
                                onChange={handleChange}
                            />
                            Cantonese
                        </label>
                        <label>
                            <input
                                type="checkbox"
                                name="languages"
                                value="Others"
                                checked={formData.languages.includes('Others')}
                                onChange={handleChange}
                            />
                            Others
                        </label>
                    </div>
                </div>
                {errors.languages && <p className="error-message">{errors.languages}</p>}
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
                        <label>Telephone:</label>
                        <InputMask
                            mask="(999) 999-9999"
                            name="telephone"
                            value={formData.telephone}
                            onChange={handleChange}
                        >
                            {(inputProps) => <input type="tel" {...inputProps} />}
                        </InputMask>
                    </div>
                    {errors.telephone && <p className="error-message">{errors.telephone}</p>}
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
                <div className="form-group">
                    <div className="form-group-row">
                        <label>Birth Place:</label>
                        <input
                            type="text"
                            name="birthPlace"
                            value={formData.birthPlace}
                            onChange={handleChange}
                        />
                    </div>
                </div>
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

            <hr /> {/* Add a horizontal line to start a new section */}


            <div className="form-group">
                <div className="question-row">The reason you come to this church?</div>
                <div className="radio-group">
                    <div className="radio-item">
                        <label>
                            <input
                                type="radio"
                                name="reasonToVisit"
                                value="visiting"
                                checked={formData.reasonToVisit.includes('visiting')}
                                onChange={handleChange}
                            />
                            are visiting
                        </label>
                        <label>
                            <input
                                type="radio"
                                name="reasonToVisit"
                                value="living"
                                checked={formData.reasonToVisit.includes('living')}
                                onChange={handleChange}
                            />
                            live in this area
                        </label>
                    </div>
                </div>
                {errors.reasonToVisit && <p className="error-message-radio">{errors.reasonToVisit}</p>}
            </div>

            <div className="form-group">
                <div className="question-row">Your relationship with God?</div>
                <div className="radio-group">
                    <div className="radio-item">
                        <label>
                            <input
                                type="radio"
                                name="relationWithGod"
                                value="Baptized"
                                checked={formData.relationWithGod.includes('Baptized')}
                                onChange={handleChange}
                            />
                            Baptized
                        </label>
                        <label>
                            <input
                                type="radio"
                                name="relationWithGod"
                                value="notbaptized"
                                checked={formData.relationWithGod.includes('notbaptized')}
                                onChange={handleChange}
                            />
                            Belive in HIM but not baptized
                        </label>
                        <label>
                            <input
                                type="radio"
                                name="relationWithGod"
                                value="Liketoknow"
                                checked={formData.relationWithGod.includes('Liketoknow')}
                                onChange={handleChange}
                            />
                            Like to know
                        </label>
                    </div>
                </div>
                {errors.relationWithGod && <p className="error-message-radio">{errors.relationWithGod}</p>}
            </div>

            <div className="form-group">
                <div className="question-row">Do you like to be visited?</div>
                <div className="radio-group">
                    <div className="radio-item">
                        <label>
                            <input
                                type="radio"
                                name="beVisited"
                                value="Yes"
                                checked={formData.beVisited.includes('Yes')}
                                onChange={handleChange}
                            />
                            Yes
                        </label>
                        <label>
                            <input
                                type="radio"
                                name="beVisited"
                                value="No"
                                checked={formData.beVisited.includes('No')}
                                onChange={handleChange}
                            />
                            No
                        </label>
                    </div>
                </div>
                {errors.beVisited && <p className="error-message-radio">{errors.beVisited}</p>}
            </div>

            <div className="form-group">
                <div className="question-row">Do you want to attend our cell group meetings?</div>
                <div className="radio-group">
                    <div className="radio-item">
                        <label>
                            <input
                                type="radio"
                                name="joinCellGroup"
                                value="Yes"
                                checked={formData.joinCellGroup.includes('Yes')}
                                onChange={handleChange}
                            />
                            Yes
                        </label>
                        <label>
                            <input
                                type="radio"
                                name="joinCellGroup"
                                value="No"
                                checked={formData.joinCellGroup.includes('No')}
                                onChange={handleChange}
                            />
                            No
                        </label>
                    </div>
                </div>
                {errors.joinCellGroup && <p className="error-message-radio">{errors.joinCellGroup}</p>}
            </div>

            <hr /> {/* Add a horizontal line to start a new section */}

            <button type="submit">Register</button>
            {message && <p>{message}</p>}
        </form>
    );
};

export default RegisterForm;