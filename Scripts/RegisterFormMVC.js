import React, { useState } from 'react';
import axios from 'axios';
import InputMask from 'react-input-mask';
import './RegisterForm1.css';

const RegisterFormMVC = () => {
    // Initialize state
    const [formData, setFormData] = useState({
        username: '',
        email: '',
        password: '',
        confirmPassword: '',
        age: '',
        languages: [],
        telephone: ''
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
        if (!formData.username) tempErrors.username = "Username is required";
        if (!formData.email) tempErrors.email = "Email is required";
        if (!formData.password) tempErrors.password = "Password is required";
        if (formData.password !== formData.confirmPassword) tempErrors.confirmPassword = "Passwords do not match";
        if (!formData.age) tempErrors.age = "Age is required";
        if (formData.languages.length === 0) tempErrors.languages = "At least one language is required";
        if (!formData.telephone) tempErrors.telephone = "Telephone number is required";
        setErrors(tempErrors);
        return Object.keys(tempErrors).length === 0;
    };

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        if (validate()) {
            axios.post('/Register/SubmitForm', formData)
                .then(response => {
                    setMessage(response.data.message);
                    if (response.data.success) {
                        setFormData({
                            username: '',
                            email: '',
                            password: '',
                            confirmPassword: '',
                            age: '',
                            languages: [],
                            telephone: ''
                        });
                        setErrors({});
                    } else {
                        setErrors(response.data.errors.reduce((acc, curr) => ({ ...acc, [curr.field]: curr.message }), {}));
                    }
                })
                .catch(error => {
                    console.error("There was an error submitting the form!", error);
                });
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-row">
                <div className="form-group">
                    <label>Username:</label>
                    <input
                        type="text"
                        name="username"
                        value={formData.username}
                        onChange={handleChange}
                    />
                    {errors.username && <p>{errors.username}</p>}
                </div>
                <div className="form-group">
                    <label>Email:</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                    />
                    {errors.email && <p>{errors.email}</p>}
                </div>
            </div>
            <div className="form-row">
                <div className="form-group">
                    <label>Age:</label>
                    <select name="age" value={formData.age} onChange={handleChange}>
                        <option value="">Select your age range</option>
                        <option value="under 20">Under 20</option>
                        <option value="21-30">21-30</option>
                        <option value="31-40">31-40</option>
                        <option value="41-55">41-55</option>
                        <option value="56 and above">56 and above</option>
                    </select>
                    {errors.age && <p>{errors.age}</p>}
                </div>
            </div>
            <div className="form-group">
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
                            value="German"
                            checked={formData.languages.includes('German')}
                            onChange={handleChange}
                        />
                        German
                    </label>
                    <label>
                        <input
                            type="checkbox"
                            name="languages"
                            value="French"
                            checked={formData.languages.includes('French')}
                            onChange={handleChange}
                        />
                        French
                    </label>
                </div>
                {errors.languages && <p>{errors.languages}</p>}
            </div>
            <div className="form-group">
                <label>Telephone:</label>
                <InputMask
                    mask="(999) 999-9999"
                    name="telephone"
                    value={formData.telephone}
                    onChange={handleChange}
                >
                    {(inputProps) => <input type="tel" {...inputProps} />}
                </InputMask>
                {errors.telephone && <p>{errors.telephone}</p>}
            </div>
            <div className="form-group">
                <label>Password:</label>
                <input
                    type="password"
                    name="password"
                    value={formData.password}
                    onChange={handleChange}
                />
                {errors.password && <p>{errors.password}</p>}
            </div>
            <div className="form-group">
                <label>Confirm Password:</label>
                <input
                    type="password"
                    name="confirmPassword"
                    value={formData.confirmPassword}
                    onChange={handleChange}
                />
                {errors.confirmPassword && <p>{errors.confirmPassword}</p>}
            </div>
            <button type="submit">Register</button>
            {message && <p>{message}</p>}
        </form>
    );
};

export default RegisterFormMVC;